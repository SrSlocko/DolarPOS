using System.Data;
using System.Text;
using DolarPOS.Entidades;
using DolarPOS.Negocio;

namespace DolarPOS.Presentacion;

public partial class FrmPuntoVenta : Form
{
    public FrmPuntoVenta()
    {
        InitializeComponent();
    }

    #region Campos

    /// <summary>0 = sin operación, 1 = nuevo registro, 2 = actualizar.</summary>
    private int _estadoGuarda;

    private int _codigo;

    #endregion

    #region Formato y estados de la interfaz

    private void FormatoListado()
    {
        if (Dgv_Listado.Columns.Count == 0) return;

        Dgv_Listado.Columns[0].Width = 100;
        Dgv_Listado.Columns[0].HeaderText = "CÓDIGO";
        if (Dgv_Listado.Columns.Count > 1)
        {
            Dgv_Listado.Columns[1].Width = 435;
            Dgv_Listado.Columns[1].HeaderText = "PUNTO DE VENTA";
        }
    }

    private void EstadoBotonesPrincipales(bool activo)
    {
        btn_Nuevo.Enabled = activo;
        btn_Actualizar.Enabled = activo;
        btn_Eliminar.Enabled = activo;
        btn_Reporte.Enabled = activo;
        btn_Salir.Enabled = activo;
    }

    private void EstadoBotonesProceso(bool activo)
    {
        btn_cancelar.Visible = activo;
        btn_guardar.Visible = activo;
        btn_retornar.Visible = !activo;
    }

    private void EstadoTexto(bool editable) => Txt_descripcion.ReadOnly = !editable;

    private void LimpiarTexto() => Txt_descripcion.Text = string.Empty;

    /// <summary>Carga el registro seleccionado en el formulario. Devuelve false si no hay selección.</summary>
    private bool SeleccionarItem()
    {
        if (Dgv_Listado.CurrentRow?.Cells["Codigo"].Value is null)
        {
            MessageBox.Show("Selecciona un registro", "Aviso del Sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        _codigo = Convert.ToInt32(Dgv_Listado.CurrentRow.Cells["Codigo"].Value);
        Txt_descripcion.Text = Convert.ToString(Dgv_Listado.CurrentRow.Cells["Descripcion"].Value) ?? string.Empty;
        return true;
    }

    private void MostrarError(Exception ex)
    {
        // El detalle técnico completo se escribe solo en la salida de depuración;
        // al usuario se le muestra un mensaje claro sin exponer el stack trace.
        System.Diagnostics.Debug.WriteLine(ex);
        MessageBox.Show(
            "No se pudo conectar con la base de datos o la operación falló.\n\n" +
            "Verifica que SQL Server esté ejecutándose y que appsettings.json tenga la cadena de conexión correcta.\n\n" +
            $"Detalle: {ex.Message}",
            "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    #endregion

    #region Carga inicial y consulta

    private async void FrmPuntoVenta_Load(object sender, EventArgs e)
    {
        await ListarAsync("%");
    }

    private async Task ListarAsync(string texto)
    {
        try
        {
            DataTable datos = await PuntoVentaNegocio.ListarAsync(texto);
            Dgv_Listado.DataSource = datos;
            FormatoListado();
            lbl_totalregistros.Text = $"Total registros: {Dgv_Listado.Rows.Count}";
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
    }

    private async void btn_buscar_Click(object sender, EventArgs e)
    {
        await ListarAsync(txt_Buscar.Text.Trim());
    }

    #endregion

    #region Mantenimiento (nuevo / actualizar / eliminar)

    private void btn_Nuevo_Click(object sender, EventArgs e)
    {
        _estadoGuarda = 1;
        _codigo = 0;
        EstadoBotonesPrincipales(false);
        EstadoBotonesProceso(true);
        LimpiarTexto();
        EstadoTexto(true);
        Tbc_principal.SelectedIndex = 1;
        Txt_descripcion.Focus();
    }

    private void btn_Actualizar_Click(object sender, EventArgs e)
    {
        if (Dgv_Listado.Rows.Count > 0 && SeleccionarItem())
        {
            _estadoGuarda = 2;
            EstadoBotonesPrincipales(false);
            EstadoBotonesProceso(true);
            EstadoTexto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion.Focus();
        }
    }

    private async void btn_guardar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Txt_descripcion.Text))
        {
            MessageBox.Show("Falta ingresar datos requeridos (*)", "Aviso del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return;
        }

        var pv = new PuntoVenta { Codigo = _codigo, Descripcion = Txt_descripcion.Text.Trim() };
        string rpta = await PuntoVentaNegocio.GuardarAsync(_estadoGuarda, pv);

        if (rpta == "OK")
        {
            MessageBox.Show("Los datos han sido guardados correctamente", "Aviso del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            _estadoGuarda = 0;
            _codigo = 0;
            LimpiarTexto();
            EstadoTexto(false);
            EstadoBotonesPrincipales(true);
            EstadoBotonesProceso(false);
            Tbc_principal.SelectedIndex = 0;
            await ListarAsync("%");
        }
        else
        {
            MessageBox.Show(rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }

    private void btn_cancelar_Click(object sender, EventArgs e)
    {
        _estadoGuarda = 0;
        _codigo = 0;
        LimpiarTexto();
        EstadoTexto(false);
        EstadoBotonesPrincipales(true);
        EstadoBotonesProceso(false);
        Tbc_principal.SelectedIndex = 0;
    }

    private void btn_retornar_Click(object sender, EventArgs e)
    {
        Tbc_principal.SelectedIndex = 0;
    }

    private async void btn_Eliminar_Click(object sender, EventArgs e)
    {
        if (Dgv_Listado.Rows.Count == 0 || !SeleccionarItem()) return;

        DialogResult opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?",
            "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (opcion != DialogResult.Yes) return;

        string rpta = await PuntoVentaNegocio.EliminarAsync(_codigo);
        if (rpta == "OK")
        {
            MessageBox.Show("El registro ha sido eliminado", "Aviso del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            await ListarAsync("%");
        }
        else
        {
            MessageBox.Show(rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        _codigo = 0;
        LimpiarTexto();
    }

    private void Dgv_Listado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
    {
        if (_estadoGuarda == 0 && e.RowIndex >= 0)
        {
            Dgv_Listado.CurrentCell = Dgv_Listado.Rows[e.RowIndex].Cells[0];
            if (SeleccionarItem())
            {
                EstadoBotonesProceso(false);
                Tbc_principal.SelectedIndex = 1;
            }
        }
    }

    #endregion

    #region Salir y reporte

    private void btn_Salir_Click(object sender, EventArgs e) => Close();

    /// <summary>
    /// Exporta el listado actual a un archivo CSV (abre directo en Excel/LibreOffice).
    /// </summary>
    private void btn_Reporte_Click(object sender, EventArgs e)
    {
        if (Dgv_Listado.Rows.Count == 0)
        {
            MessageBox.Show("No hay registros para exportar.", "Aviso del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        using var dialogo = new SaveFileDialog
        {
            Title = "Exportar listado de puntos de venta",
            Filter = "Archivo CSV (*.csv)|*.csv",
            FileName = $"PuntosDeVenta_{DateTime.Now:yyyyMMdd_HHmm}.csv"
        };

        if (dialogo.ShowDialog() != DialogResult.OK) return;

        try
        {
            var sb = new StringBuilder();
            var columnas = Dgv_Listado.Columns.Cast<DataGridViewColumn>()
                .Select(c => c.HeaderText ?? c.Name);
            sb.AppendLine(string.Join(";", columnas));

            foreach (DataGridViewRow fila in Dgv_Listado.Rows)
            {
                sb.AppendLine(string.Join(";",
                    fila.Cells.Cast<DataGridViewCell>().Select(c => c.Value?.ToString())));
            }

            // BOM UTF-8 para que Excel reconozca los acentos correctamente.
            File.WriteAllText(dialogo.FileName, sb.ToString(), new UTF8Encoding(true));
            MessageBox.Show("Listado exportado correctamente.", "Aviso del sistema",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MostrarError(ex);
        }
    }

    #endregion
}
