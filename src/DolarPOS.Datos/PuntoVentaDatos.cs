using System.Data;
using DolarPOS.Entidades;
using Microsoft.Data.SqlClient;

namespace DolarPOS.Datos;

/// <summary>
/// Acceso a datos de la tabla PuntoVenta.
/// Todos los métodos usan procedimientos almacenados y liberan los recursos con <c>using</c>.
/// </summary>
public sealed class PuntoVentaDatos
{
    /// <summary>Lista los puntos de venta cuya descripción contiene <paramref name="texto"/> ("% " = todos).</summary>
    public async Task<DataTable> ListarAsync(string texto, CancellationToken cancel = default)
    {
        var tabla = new DataTable();
        await using var conexion = Conexion.Instancia.CrearConexion();
        await using var comando = new SqlCommand("USP_PuntoVenta_Listar", conexion)
        {
            CommandType = CommandType.StoredProcedure,
            CommandTimeout = 60
        };
        comando.Parameters.Add("@Texto", SqlDbType.VarChar, 100).Value = texto;

        await conexion.OpenAsync(cancel);
        await using var lector = await comando.ExecuteReaderAsync(cancel);
        tabla.Load(lector);
        return tabla;
    }

    /// <summary>
    /// Inserta (nOpcion = 1) o actualiza (nOpcion = 2) un punto de venta.
    /// Devuelve "OK" o el mensaje de error.
    /// </summary>
    public async Task<string> GuardarAsync(int nOpcion, PuntoVenta pv, CancellationToken cancel = default)
    {
        try
        {
            await using var conexion = Conexion.Instancia.CrearConexion();
            await using var comando = new SqlCommand("USP_PuntoVenta_Guardar", conexion)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 60
            };
            comando.Parameters.Add("@Opcion", SqlDbType.Int).Value = nOpcion;
            comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = pv.Codigo;
            comando.Parameters.Add("@Descripcion", SqlDbType.VarChar, 100).Value = pv.Descripcion.Trim();

            await conexion.OpenAsync(cancel);
            await comando.ExecuteNonQueryAsync(cancel);
            return "OK";
        }
        catch (SqlException ex) when (ex.Number is 2601 or 2627) // índice único duplicado
        {
            return "Ya existe un punto de venta con esa descripción.";
        }
    }

    /// <summary>Elimina un punto de venta por código. Devuelve "OK" o el mensaje de error.</summary>
    public async Task<string> EliminarAsync(int codigo, CancellationToken cancel = default)
    {
        await using var conexion = Conexion.Instancia.CrearConexion();
        await using var comando = new SqlCommand("USP_PuntoVenta_Eliminar", conexion)
        {
            CommandType = CommandType.StoredProcedure,
            CommandTimeout = 60
        };
        comando.Parameters.Add("@Codigo", SqlDbType.Int).Value = codigo;

        await conexion.OpenAsync(cancel);
        int filas = await comando.ExecuteNonQueryAsync(cancel);
        return filas >= 1 ? "OK" : "No se pudo eliminar el registro.";
    }
}
