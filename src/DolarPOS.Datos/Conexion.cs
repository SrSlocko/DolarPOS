using Microsoft.Data.SqlClient;

namespace DolarPOS.Datos;

/// <summary>
/// Fábrica de conexiones a SQL Server.
/// La cadena de conexión se lee de appsettings.json (junto al ejecutable)
/// o de la variable de entorno DOLARPOS_CADENA_CONEXION (tiene prioridad).
/// Nunca se guardan credenciales en el código fuente.
/// </summary>
public sealed class Conexion
{
    private static readonly Lazy<Conexion> _instancia = new(() => new Conexion(), LazyThreadSafetyMode.ExecutionAndPublication);

    private readonly string _cadenaConexion;

    private Conexion()
    {
        _cadenaConexion = Configuracion.CadenaConexion;
    }

    /// <summary>Devuelve una conexión nueva (abierta por el llamador o con <c>await using</c>).</summary>
    public SqlConnection CrearConexion() => new(_cadenaConexion);

    public static Conexion Instancia => _instancia.Value;
}
