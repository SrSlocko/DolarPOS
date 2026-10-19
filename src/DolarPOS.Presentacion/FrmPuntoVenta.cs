using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dolar_PuntoVenta.Entidades;
using Dolar_PuntoVenta.Negocio;

namespace Dolar_PuntoVenta.Presentacion
{
    public partial class Frm_Punto_Venta : Form
    {
        public Frm_Punto_Venta()
        {
            InitializeComponent();
        }

        #region "Mis variables"
        int nCodigo = 0;
        int Estadoguarda = 0;
        #endregion

        #region "Mi metodos"

        private void Formato_pv()
        {
            Dgv_Listado.Columns[0].Width = 100;
            Dgv_Listado.Columns[0].HeaderText = "CODIGO_PV";
            Dgv_Listado.Columns[1].Width = 435;
            Dgv_Listado.Columns[1].HeaderText = "PUNTO DE VENTA";
        }


        private void Frm_Punto_Venta_Load(object sender, EventArgs e)
        {
            this.Listado_pv("%");

        }
        private void Listado_pv(string cTexto)
        {
            try
            {
                Dgv_Listado.DataSource = N_Punto_Venta.Listado_pv(cTexto);
                this.Formato_pv();
                lbl_totalregistros.Text = "Total registros:" +Convert.ToString( Dgv_Listado.Rows.Count);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Estado_BotonesPrincipales(bool lEstado)
        {
            btn_Nuevo.Enabled = lEstado;
            btn_Actualizar.Enabled = lEstado;
            btn_Eliminar.Enabled = lEstado;          
            btn_Reporte.Enabled = lEstado;
            btn_Salir.Enabled = lEstado;

        }
        private void Limpia_texto()
        {
            Txt_descripcion.Text = "";       
        }
        private void Estado_texto (bool lEstado)
        {
            Txt_descripcion.ReadOnly = !lEstado;

        }
        private void Selecciona_item()
        {
            if (string.IsNullOrEmpty(Convert.ToString (Dgv_Listado.CurrentRow.Cells["codigo_pv"].Value)))
                {
                MessageBox.Show("Selecciona un registro",
                    "Aviso del Sistema", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);

            }
            else
            {
                this.nCodigo = Convert.ToInt32 (Dgv_Listado.CurrentRow.Cells["codigo_pv"].Value);
                Txt_descripcion.Text =Convert.ToString(Dgv_Listado.CurrentRow.Cells["descripcion_pv"].Value);
            }
        }
        private void Estado_BotonesProceso(bool lEstado) {

            btn_cancelar.Visible = lEstado;
            btn_guardar.Visible = lEstado;
            btn_retornar.Visible = !lEstado;

        }

        #endregion

        private void btn_Nuevo_Click(object sender, EventArgs e)
        {
            this.Estadoguarda = 1;  // new register
            this.Estado_BotonesPrincipales(false);
            this.Estado_BotonesProceso(true);
            this.Limpia_texto();
            this.Estado_texto(true);
            Tbc_principal.SelectedIndex = 1;
            Txt_descripcion.Focus();
        }

        private void btn_cancelar_Click(object sender, EventArgs e)
        {
            this.Limpia_texto();
            this.Estado_texto(false);
            this.Estado_BotonesPrincipales(true);
            this.Estado_BotonesProceso(false);
            Tbc_principal.SelectedIndex = 0;
        }

        private void btn_retornar_Click(object sender, EventArgs e)
        {
            Tbc_principal.SelectedIndex = 0;
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            try
            {
                if(Txt_descripcion.Text == String.Empty)
                {
                    MessageBox.Show("Falta ingresar datos requeridos (*)",
                        "Aviso del sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Exclamation);
                }
                else
                {
                    string Rpta = "";
                    E_Punto_Venta oPropiedad = new E_Punto_Venta();
                    oPropiedad.Codigo_pv = this.nCodigo;
                    oPropiedad.Descripcion_pv = Txt_descripcion.Text.Trim();
                    Rpta = N_Punto_Venta.Guardar_pv(this.Estadoguarda, oPropiedad);
                    if (Rpta.Equals("OK"))
                    {
                        MessageBox.Show("Los datos han sido guardados correctamente",
                            "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Limpia_texto();
                        this.Estado_texto(false);
                        this.Estado_BotonesPrincipales(true);
                        this.Estado_BotonesProceso(false);
                        this.Estadoguarda = 0;
                        this.Listado_pv("%");
                        Tbc_principal.SelectedIndex = 0;
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count>0)
            {
                this.Estadoguarda = 2; // actualizar registro
                this.Estado_BotonesPrincipales(false);
                this.Estado_BotonesProceso(true);
                this.Estado_texto(true);
                this.Limpia_texto();
                this.Selecciona_item();
                Tbc_principal.SelectedIndex = 1;
                Txt_descripcion.Focus();

            }
        }

        private void Dgv_Listado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.Estadoguarda==0)
            {
                this.Selecciona_item();
                this.Estado_BotonesProceso(false);
                Tbc_principal.SelectedIndex = 1;
            }        
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            if (Dgv_Listado.Rows.Count > 0)
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Estas seguro de eliminar el registro seleccionado","Aviso del Sistema", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (Opcion== DialogResult.Yes)
                {
                    string Rpta = "";
                    this.Selecciona_item();
                    Rpta = N_Punto_Venta.Eliminar_pv(this.nCodigo);
                    if (Rpta.Equals("OK"))
                    {
                        this.Listado_pv("%");
                        MessageBox.Show("El registro ha sido eliminado",
                            "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show(Rpta, "Aviso del sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    this.Limpia_texto();

                }
                
                             
            }
        }

        private void btn_buscar_Click(object sender, EventArgs e)
        {
            this.Listado_pv(txt_Buscar.Text.Trim());
        }
    }
}
