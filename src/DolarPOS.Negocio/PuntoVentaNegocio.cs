using System.Data;
using DolarPOS.Datos;
using DolarPOS.Entidades;

namespace DolarPOS.Negocio;

/// <summary>
/// Capa de negocio: única puerta de entrada para la presentación.
/// Valida los datos antes de delegar en la capa de acceso a datos.
/// </summary>
public static class PuntoVentaNegocio
{
    private const int LongitudMaxima = 100;

    public static Task<DataTable> ListarAsync(string texto, CancellationToken cancel = default)
        => new PuntoVentaDatos().ListarAsync(texto, cancel);

    public static async Task<string> GuardarAsync(int nOpcion, PuntoVenta pv, CancellationToken cancel = default)
    {
        if (string.IsNullOrWhiteSpace(pv.Descripcion))
        {
            return "La descripción es obligatoria.";
        }

        pv.Descripcion = pv.Descripcion.Trim();
        if (pv.Descripcion.Length > LongitudMaxima)
        {
            return $"La descripción no puede superar {LongitudMaxima} caracteres.";
        }

        return await new PuntoVentaDatos().GuardarAsync(nOpcion, pv, cancel);
    }

    public static Task<string> EliminarAsync(int codigo, CancellationToken cancel = default)
    {
        if (codigo <= 0)
        {
            return Task.FromResult("Selecciona un registro válido.");
        }

        return new PuntoVentaDatos().EliminarAsync(codigo, cancel);
    }
}
