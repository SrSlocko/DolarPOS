namespace Dolar_PuntoVenta.Presentacion
{
    partial class Frm_Punto_Venta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Punto_Venta));
            this.Tbc_principal = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lbl_totalregistros = new System.Windows.Forms.Label();
            this.btn_buscar = new System.Windows.Forms.Button();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Dgv_Listado = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_cancelar = new System.Windows.Forms.Button();
            this.btn_guardar = new System.Windows.Forms.Button();
            this.btn_retornar = new System.Windows.Forms.Button();
            this.Txt_descripcion = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Nuevo = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.Tbc_principal.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Listado)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Tbc_principal
            // 
            this.Tbc_principal.Controls.Add(this.tabPage2);
            this.Tbc_principal.Controls.Add(this.tabPage1);
            this.Tbc_principal.Dock = System.Windows.Forms.DockStyle.Top;
            this.Tbc_principal.ItemSize = new System.Drawing.Size(100, 30);
            this.Tbc_principal.Location = new System.Drawing.Point(0, 0);
            this.Tbc_principal.Name = "Tbc_principal";
            this.Tbc_principal.SelectedIndex = 0;
            this.Tbc_principal.Size = new System.Drawing.Size(664, 379);
            this.Tbc_principal.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.PapayaWhip;
            this.tabPage2.Controls.Add(this.lbl_totalregistros);
            this.tabPage2.Controls.Add(this.btn_buscar);
            this.tabPage2.Controls.Add(this.txt_Buscar);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.Dgv_Listado);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(656, 341);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Consultas";
            // 
            // lbl_totalregistros
            // 
            this.lbl_totalregistros.AutoSize = true;
            this.lbl_totalregistros.Location = new System.Drawing.Point(513, 313);
            this.lbl_totalregistros.Name = "lbl_totalregistros";
            this.lbl_totalregistros.Size = new System.Drawing.Size(88, 13);
            this.lbl_totalregistros.TabIndex = 4;
            this.lbl_totalregistros.Text = "Total registros : 0";
            // 
            // btn_buscar
            // 
            this.btn_buscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(145)))), ((int)(((byte)(134)))));
            this.btn_buscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(235)))), ((int)(((byte)(211)))));
            this.btn_buscar.Location = new System.Drawing.Point(283, 28);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_buscar.TabIndex = 3;
            this.btn_buscar.Text = "Buscar";
            this.btn_buscar.UseVisualStyleBackColor = false;
            this.btn_buscar.Click += new System.EventHandler(this.btn_buscar_Click);
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Location = new System.Drawing.Point(73, 28);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(204, 20);
            this.txt_Buscar.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buscar";
            // 
            // Dgv_Listado
            // 
            this.Dgv_Listado.AllowUserToAddRows = false;
            this.Dgv_Listado.AllowUserToDeleteRows = false;
            this.Dgv_Listado.AllowUserToOrderColumns = true;
            this.Dgv_Listado.BackgroundColor = System.Drawing.Color.White;
            this.Dgv_Listado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Dgv_Listado.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.Dgv_Listado.ColumnHeadersHeight = 35;
            this.Dgv_Listado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Dgv_Listado.EnableHeadersVisualStyles = false;
            this.Dgv_Listado.Location = new System.Drawing.Point(21, 61);
            this.Dgv_Listado.Name = "Dgv_Listado";
            this.Dgv_Listado.ReadOnly = true;
            this.Dgv_Listado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Dgv_Listado.Size = new System.Drawing.Size(580, 237);
            this.Dgv_Listado.TabIndex = 0;
            this.Dgv_Listado.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_Listado_CellDoubleClick);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.tabPage1.Controls.Add(this.btn_cancelar);
            this.tabPage1.Controls.Add(this.btn_guardar);
            this.tabPage1.Controls.Add(this.btn_retornar);
            this.tabPage1.Controls.Add(this.Txt_descripcion);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(656, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Mantenimiento";
            // 
            // btn_cancelar
            // 
            this.btn_cancelar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_cancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_cancelar.ForeColor = System.Drawing.Color.White;
            this.btn_cancelar.Location = new System.Drawing.Point(126, 60);
            this.btn_cancelar.Name = "btn_cancelar";
            this.btn_cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_cancelar.TabIndex = 6;
            this.btn_cancelar.Text = "Cancelar";
            this.btn_cancelar.UseVisualStyleBackColor = false;
            this.btn_cancelar.Visible = false;
            this.btn_cancelar.Click += new System.EventHandler(this.btn_cancelar_Click);
            // 
            // btn_guardar
            // 
            this.btn_guardar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_guardar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_guardar.ForeColor = System.Drawing.Color.White;
            this.btn_guardar.Location = new System.Drawing.Point(207, 60);
            this.btn_guardar.Name = "btn_guardar";
            this.btn_guardar.Size = new System.Drawing.Size(75, 23);
            this.btn_guardar.TabIndex = 5;
            this.btn_guardar.Text = "Guardar";
            this.btn_guardar.UseVisualStyleBackColor = false;
            this.btn_guardar.Visible = false;
            this.btn_guardar.Click += new System.EventHandler(this.btn_guardar_Click);
            // 
            // btn_retornar
            // 
            this.btn_retornar.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btn_retornar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_retornar.ForeColor = System.Drawing.Color.White;
            this.btn_retornar.Location = new System.Drawing.Point(293, 60);
            this.btn_retornar.Name = "btn_retornar";
            this.btn_retornar.Size = new System.Drawing.Size(75, 23);
            this.btn_retornar.TabIndex = 4;
            this.btn_retornar.Text = "Retornar";
            this.btn_retornar.UseVisualStyleBackColor = false;
            this.btn_retornar.Visible = false;
            this.btn_retornar.Click += new System.EventHandler(this.btn_retornar_Click);
            // 
            // Txt_descripcion
            // 
            this.Txt_descripcion.Location = new System.Drawing.Point(100, 24);
            this.Txt_descripcion.Name = "Txt_descripcion";
            this.Txt_descripcion.ReadOnly = true;
            this.Txt_descripcion.Size = new System.Drawing.Size(312, 20);
            this.Txt_descripcion.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(13, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Punto de Venta";
            // 
            // btn_Nuevo
            // 
            this.btn_Nuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.btn_Nuevo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(116)))), ((int)(((byte)(170)))));
            this.btn_Nuevo.FlatAppearance.BorderSize = 2;
            this.btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Nuevo.ImageIndex = 0;
            this.btn_Nuevo.ImageList = this.imageList1;
            this.btn_Nuevo.Location = new System.Drawing.Point(25, 385);
            this.btn_Nuevo.Name = "btn_Nuevo";
            this.btn_Nuevo.Size = new System.Drawing.Size(63, 51);
            this.btn_Nuevo.TabIndex = 1;
            this.btn_Nuevo.Text = "Nuevo";
            this.btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Nuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Nuevo.UseVisualStyleBackColor = false;
            this.btn_Nuevo.Click += new System.EventHandler(this.btn_Nuevo_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "nuevo.png");
            this.imageList1.Images.SetKeyName(1, "actualizar.png");
            this.imageList1.Images.SetKeyName(2, "reporte.png");
            this.imageList1.Images.SetKeyName(3, "eliminar.png");
            this.imageList1.Images.SetKeyName(4, "salir.png");
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.btn_Actualizar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(116)))), ((int)(((byte)(170)))));
            this.btn_Actualizar.FlatAppearance.BorderSize = 2;
            this.btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Actualizar.ImageKey = "actualizar.png";
            this.btn_Actualizar.ImageList = this.imageList1;
            this.btn_Actualizar.Location = new System.Drawing.Point(94, 385);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(68, 51);
            this.btn_Actualizar.TabIndex = 2;
            this.btn_Actualizar.Text = "Actualizar";
            this.btn_Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Actualizar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Actualizar.UseVisualStyleBackColor = false;
            this.btn_Actualizar.Click += new System.EventHandler(this.btn_Actualizar_Click);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.btn_Eliminar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(116)))), ((int)(((byte)(170)))));
            this.btn_Eliminar.FlatAppearance.BorderSize = 2;
            this.btn_Eliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Eliminar.ImageKey = "eliminar.png";
            this.btn_Eliminar.ImageList = this.imageList1;
            this.btn_Eliminar.Location = new System.Drawing.Point(168, 385);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(63, 51);
            this.btn_Eliminar.TabIndex = 3;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Eliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Eliminar.UseVisualStyleBackColor = false;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.btn_Reporte.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(116)))), ((int)(((byte)(170)))));
            this.btn_Reporte.FlatAppearance.BorderSize = 2;
            this.btn_Reporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reporte.ImageKey = "reporte.png";
            this.btn_Reporte.ImageList = this.imageList1;
            this.btn_Reporte.Location = new System.Drawing.Point(237, 385);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(63, 51);
            this.btn_Reporte.TabIndex = 4;
            this.btn_Reporte.Text = "Reporte";
            this.btn_Reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Reporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Reporte.UseVisualStyleBackColor = false;
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(253)))), ((int)(((byte)(255)))));
            this.btn_Salir.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(116)))), ((int)(((byte)(170)))));
            this.btn_Salir.FlatAppearance.BorderSize = 2;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Salir.ImageKey = "salir.png";
            this.btn_Salir.ImageList = this.imageList1;
            this.btn_Salir.Location = new System.Drawing.Point(311, 385);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(63, 51);
            this.btn_Salir.TabIndex = 5;
            this.btn_Salir.Text = "Salir";
            this.btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Salir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Salir.UseVisualStyleBackColor = false;
            // 
            // Frm_Punto_Venta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(103)))), ((int)(((byte)(145)))), ((int)(((byte)(134)))));
            this.ClientSize = new System.Drawing.Size(664, 442);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_Actualizar);
            this.Controls.Add(this.btn_Nuevo);
            this.Controls.Add(this.Tbc_principal);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_Punto_Venta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Punto de Venta";
            this.Load += new System.EventHandler(this.Frm_Punto_Venta_Load);
            this.Tbc_principal.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Dgv_Listado)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tbc_principal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView Dgv_Listado;
        private System.Windows.Forms.Button btn_cancelar;
        private System.Windows.Forms.Button btn_guardar;
        private System.Windows.Forms.Button btn_retornar;
        private System.Windows.Forms.TextBox Txt_descripcion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbl_totalregistros;
    }
}