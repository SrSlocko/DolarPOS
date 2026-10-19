using Microsoft.Extensions.Configuration;

namespace DolarPOS.Datos;

/// <summary>
/// Carga la configuración de la aplicación.
/// Orden de precedencia:
///   1. Variable de entorno DOLARPOS_CADENA_CONEXION
///   2. appsettings.json junto al ejecutable
///   3. (opcional) appsettings.Production.json si existe
/// </summary>
internal static class Configuracion
{
    private const string VariableEntorno = "DOLARPOS_CADENA_CONEXION";

    public static string CadenaConexion { get; } = Cargar();

    private static string Cargar()
    {
        var porEntorno = Environment.GetEnvironmentVariable(VariableEntorno);
        if (!string.IsNullOrWhiteSpace(porEntorno))
        {
            return porEntorno;
        }

        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
            .AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: false)
            .AddEnvironmentVariables()
            .Build();

        var cadena = config.GetConnectionString("DolarPOS");
        if (string.IsNullOrWhiteSpace(cadena))
        {
            throw new InvalidOperationException(
                "Falta la cadena de conexión. Agrégala en appsettings.json " +
                $"(<add name=\"DolarPOS\" ... />) o define la variable de entorno {VariableEntorno}.");
        }

        return cadena;
    }
}
