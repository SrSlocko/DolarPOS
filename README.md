# DolarPOS 💵

Sistema de **punto de venta** escrito en **C# / .NET 10** con **SQL Server**, arquitectura por capas
(Datos · Negocio · Entidades · Presentación) e interfaz **Windows Forms**.

> Migrado en 2026 desde .NET Framework 4.7.2 a **.NET 10 LTS** (soporte hasta noviembre 2028),
> con corrección de errores, credenciales fuera del código fuente y build moderno.

---

## ✨ Características

- **Alta, consulta, actualización y baja** de puntos de venta (CRUD completo).
- **Búsqueda en vivo** por descripción.
- **Reporte**: exporta el listado actual a **CSV** (abre en Excel o LibreOffice).
- Arquitectura en capas separadas, lista para crecer (productos, ventas, facturación...).
- Sin credenciales en el código: la cadena de conexión se lee de `appsettings.json` o de una
  variable de entorno.
- Build reproducible en **Windows, Linux y macOS** (el ejecutable corre en Windows).

---

## 🧱 Estructura del proyecto

```
DolarPOS/
├── DolarPOS.sln
├── Directory.Build.props          # Configuración compartida (versión, nullable, etc.)
├── database/
│   └── BD_PUNTOVENTA.sql          # Script de BD + procedimientos almacenados
└── src/
    ├── DolarPOS.Entidades/        # Clases/objetos que viajan entre capas
    ├── DolarPOS.Datos/            # Acceso a SQL Server (Microsoft.Data.SqlClient)
    ├── DolarPOS.Negocio/          # Reglas de validación
    └── DolarPOS.Presentacion/     # Windows Forms (proyecto de arranque)
```

| Capa | Responsabilidad |
|------|-----------------|
| **Entidades** | Objetos simples (`PuntoVenta`) compartidos por todas las capas |
| **Datos** | Consultas y procedimientos almacenados; abre/cierra conexiones |
| **Negocio** | Valida los datos antes de tocar la base de datos |
| **Presentación** | Formulario WinForms; solo habla con la capa de Negocio |

---

## 📋 Requisitos

### Para ejecutar (Windows)
- Windows 10/11 (x64).
- **SQL Server** (Express, Developer u otra edición) o una instancia en contenedor.
- Si usas el `.exe` autocontenido de las releases, **no** necesitas instalar .NET.

### Para compilar (Windows, Linux o macOS)
- **.NET 10 SDK** → <https://dotnet.microsoft.com/download/dotnet/10.0>
- SQL Server accesible (local o remoto).

---

## 🗄️ 1. Preparar la base de datos

El script `database/BD_PUNTOVENTA.sql` crea la base de datos, la tabla y los
procedimientos almacenados (`USP_PuntoVenta_Listar`, `USP_PuntoVenta_Guardar`,
`USP_PuntoVenta_Eliminar`) e inserta datos de prueba.

### Opción A — SQL Server en Windows (SSMS o sqlcmd)

1. Instala **SQL Server Express** y **SSMS** (o Azure Data Studio).
2. Abre `database/BD_PUNTOVENTA.sql` y ejecútalo (F5).

Con `sqlcmd`:
```bash
sqlcmd -S localhost\SQLEXPRESS -E -i database/BD_PUNTOVENTA.sql
```
(`-E` = autenticación de Windows; si usas login SQL: `-U sa -P TuPassword`)

### Opción B — SQL Server en Docker (Linux, macOS o Windows)

```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=TuPasswordFuerte123" \
  -p 1433:1433 --name dolarpos-sql -d mcr.microsoft.com/mssql/server:2022-latest

# Copia el script al contenedor y ejecútalo
docker cp database/BD_PUNTOVENTA.sql dolarpos-sql:/script.sql
docker exec -it dolarpos-sql /opt/mssql-tools18/bin/sqlcmd \
  -S localhost -U sa -P "TuPasswordFuerte123" -C -i /script.sql
```
> `--name dolarpos-sql` y la imagen `2022-latest`; en Apple Silicon agrega `--platform linux/amd64`.

---

## ⚙️ 2. Configurar la cadena de conexión

La cadena vive en **`src/DolarPOS.Presentacion/appsettings.json`**. Edita el `Server`
según tu caso:

```json
{
  "ConnectionStrings": {
    "DolarPOS": "Server=localhost\\SQLEXPRESS;Database=BD_PUNTOVENTA;Integrated Security=True;TrustServerCertificate=True"
  }
}
```

**Ejemplos comunes:**

| Escenario | Cadena |
|-----------|--------|
| Windows, autenticación de Windows | `Server=localhost\SQLEXPRESS;Database=BD_PUNTOVENTA;Integrated Security=True;TrustServerCertificate=True` |
| Login SQL (usuario `sa`) | `Server=localhost,1433;Database=BD_PUNTOVENTA;User Id=sa;Password=TuPassword;TrustServerCertificate=True` |
| SQL en otra máquina | Cambia `localhost` por la IP o nombre del servidor |

> `TrustServerCertificate=True` es útil con certificados autofirmados en desarrollo.
> En producción, usa un certificado válido y quítalo.

**Alternativa sin tocar archivos (recomendada en servidores):** variable de entorno.

```bash
# Linux / macOS
export DOLARPOS_CADENA_CONEXION="Server=localhost,1433;Database=BD_PUNTOVENTA;User Id=sa;Password=TuPassword;TrustServerCertificate=True"
```
```powershell
# Windows (PowerShell, solo para esta sesión)
$env:DOLARPOS_CADENA_CONEXION="Server=localhost\SQLEXPRESS;Database=BD_PUNTOVENTA;Integrated Security=True;TrustServerCertificate=True"
```
La variable de entorno tiene **prioridad** sobre `appsettings.json`.

---

## 🚀 3. Compilar y ejecutar

### Windows

```powershell
# Restaurar y compalar
dotnet build DolarPOS.sln -c Release

# Ejecutar
dotnet run --project src/DolarPOS.Presentacion -c Release
```

### Linux o macOS (compilar; ejecutar requiere Windows)

El proyecto de Presentación es WinForms (`net10.0-windows`), así que **se compila en Linux**
pero **solo se ejecuta en Windows**. Para desarrollo en Linux, compila las capas de lógica
y usa la Presentación en una máquina Windows o VM.

```bash
# En Linux, el SDK necesita EnableWindowsTargeting (ya activado en el csproj)
dotnet build DolarPOS.sln -c Release
```

### Publicar un ejecutable autocontenido (Windows x64)

Genera un único `DolarPOS.exe` que **no requiere instalar .NET** en la máquina destino:

```bash
dotnet publish src/DolarPOS.Presentacion/DolarPOS.Presentacion.csproj \
  -c Release -r win-x64 --self-contained true \
  -p:PublishSingleFile=true -p:DebugType=None -o publish
```

Copia `publish/` al destino. **`appsettings.json` queda junto al `.exe`** y es allí donde se
configura la conexión en la máquina final.

---

## ▶️ Uso de la aplicación

1. Al iniciar se carga la lista de puntos de venta.
2. **Nuevo** → escribe la descripción → **Guardar** (opción 1: insertar).
3. **Actualizar** o doble clic en una fila → edita → **Guardar** (opción 2).
4. **Eliminar** → confirma → borra el registro.
5. **Buscar** → filtra por descripción.
6. **Reporte** → exporta el listado visible a un archivo CSV.
7. **Salir** → cierra la aplicación.

La descripción es **obligatoria**, **única** y de máximo **100 caracteres**; la validación
ocurre tanto en la capa de Negocio como en la base de datos (índice único).

---

## 🔍 Solución de problemas

| Problema | Solución |
|----------|----------|
| *"No se pudo conectar con la base de datos..."* | Verifica que SQL Server esté corriendo y que `appsettings.json` (o la variable de entorno) tenga la cadena correcta. |
| Error de conexión `SSL/TLS` | Añade `TrustServerCertificate=True` (dev) o instala el certificado real (prod). |
| Error `Login failed for user` | Revisa usuario/contraseña, o usa `Integrated Security=True` en Windows. |
| El SP no existe | Ejecuta de nuevo `database/BD_PUNTOVENTA.sql` (usa `CREATE OR ALTER`). |
| *"Ya existe un punto de venta con esa descripción"* | Es el índice único: usa otro nombre o edita el existente. |

---

## 🛠️ Tecnologías

- **.NET 10 LTS** / C# (nullable habilitado, `ImplicitUsings`)
- **Windows Forms** (interfaz de escritorio)
- **Microsoft.Data.SqlClient** (driver oficial y mantenido de SQL Server)
- **Microsoft.Extensions.Configuration** (appsettings + variables de entorno)
- **SQL Server** (procedimientos almacenados)

---

## 📦 Release

Para publicar una release con ejecutable incluido, crea y sube una etiqueta:

```bash
git tag v2.0.0
git push origin v2.0.0
```

GitHub Actions compila, genera `DolarPOS-win-x64.zip` y lo adjunta a la release automáticamente.

---

## 📄 Licencia

MIT — ver [LICENSE](LICENSE).
