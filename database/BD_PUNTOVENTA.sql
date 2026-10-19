/* ============================================================
   DolarPOS - Script de base de datos
   Base de datos: BD_PUNTOVENTA
   Compatible con: SQL Server 2016 o superior (incluye Express)
   Ejecutar con: sqlcmd, SSMS o Azure Data Studio
   ============================================================ */

IF DB_ID('BD_PUNTOVENTA') IS NULL
BEGIN
    CREATE DATABASE BD_PUNTOVENTA;
    PRINT 'Base de datos BD_PUNTOVENTA creada.';
END
GO

USE BD_PUNTOVENTA;
GO

/* ---------- Tabla ---------- */

IF OBJECT_ID('dbo.PuntoVenta', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.PuntoVenta
    (
        Codigo      INT           IDENTITY(1,1) NOT NULL,
        Descripcion VARCHAR(100)  NOT NULL,
        CONSTRAINT PK_PuntoVenta PRIMARY KEY CLUSTERED (Codigo),
        -- Evita descripciones repetidas (la app muestra un mensaje amigable)
        CONSTRAINT UQ_PuntoVenta_Descripcion UNIQUE (Descripcion)
    );
    PRINT 'Tabla dbo.PuntoVenta creada.';
END
GO

/* ---------- Procedimientos almacenados ---------- */

CREATE OR ALTER PROCEDURE dbo.USP_PuntoVenta_Listar
    @Texto VARCHAR(100) = '%'
AS
BEGIN
    SET NOCOUNT ON;

    -- "%" o cadena vacía = listado completo
    SELECT Codigo, Descripcion
    FROM dbo.PuntoVenta
    WHERE @Texto IN ('', '%')
       OR Descripcion LIKE '%' + @Texto + '%'
    ORDER BY Descripcion;
END
GO

CREATE OR ALTER PROCEDURE dbo.USP_PuntoVenta_Guardar
    @Opcion     INT,           -- 1 = Insertar, 2 = Actualizar
    @Codigo     INT,
    @Descripcion VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    IF @Opcion = 1
    BEGIN
        INSERT INTO dbo.PuntoVenta (Descripcion) VALUES (@Descripcion);
    END
    ELSE IF @Opcion = 2
    BEGIN
        UPDATE dbo.PuntoVenta
        SET Descripcion = @Descripcion
        WHERE Codigo = @Codigo;
    END
    ELSE
    BEGIN
        RAISERROR('Opción no válida (1=Insertar, 2=Actualizar).', 16, 1);
    END
END
GO

CREATE OR ALTER PROCEDURE dbo.USP_PuntoVenta_Eliminar
    @Codigo INT
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM dbo.PuntoVenta WHERE Codigo = @Codigo;
END
GO

/* ---------- Datos de prueba (opcional) ---------- */

IF NOT EXISTS (SELECT 1 FROM dbo.PuntoVenta)
BEGIN
    INSERT INTO dbo.PuntoVenta (Descripcion)
    VALUES ('Sucursal Central'), ('Sucursal Norte'), ('Cafetería Móvil');
    PRINT 'Datos de prueba insertados.';
END
GO

PRINT 'Listo. BD_PUNTOVENTA está preparada para DolarPOS.';
GO
