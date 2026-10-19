namespace DolarPOS.Entidades;

/// <summary>
/// Entidad que representa un punto de venta registrado en la base de datos.
/// </summary>
public sealed class PuntoVenta
{
    /// <summary>Identificador autogenerado por la base de datos (0 = nuevo).</summary>
    public int Codigo { get; set; }

    /// <summary>Nombre o descripción del punto de venta (obligatorio, máx. 100 caracteres).</summary>
    public string Descripcion { get; set; } = string.Empty;
}
