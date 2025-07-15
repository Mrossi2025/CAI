namespace TPCAI
{
    partial class Menu_Egresados
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
            this.cmbCarrera = new System.Windows.Forms.ComboBox();
            this.grpReportes = new System.Windows.Forms.GroupBox();
            this.btnReporte = new System.Windows.Forms.Button();
            this.lblCarrera = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Registro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PromedioFinal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TituloHonorificoAsignado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbCarrera
            // 
            this.cmbCarrera.FormattingEnabled = true;
            this.cmbCarrera.Location = new System.Drawing.Point(218, 67);
            this.cmbCarrera.Name = "cmbCarrera";
            this.cmbCarrera.Size = new System.Drawing.Size(299, 24);
            this.cmbCarrera.TabIndex = 0;
            // 
            // grpReportes
            // 
            this.grpReportes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpReportes.Controls.Add(this.dataGridView1);
            this.grpReportes.Controls.Add(this.btnReporte);
            this.grpReportes.Controls.Add(this.lblCarrera);
            this.grpReportes.Controls.Add(this.cmbCarrera);
            this.grpReportes.Location = new System.Drawing.Point(12, 24);
            this.grpReportes.Name = "grpReportes";
            this.grpReportes.Size = new System.Drawing.Size(757, 414);
            this.grpReportes.TabIndex = 1;
            this.grpReportes.TabStop = false;
            this.grpReportes.Text = "Generar Reportes";
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(313, 97);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(103, 62);
            this.btnReporte.TabIndex = 2;
            this.btnReporte.Text = "Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            // 
            // lblCarrera
            // 
            this.lblCarrera.AutoSize = true;
            this.lblCarrera.Location = new System.Drawing.Point(310, 48);
            this.lblCarrera.Name = "lblCarrera";
            this.lblCarrera.Size = new System.Drawing.Size(123, 16);
            this.lblCarrera.TabIndex = 1;
            this.lblCarrera.Text = "Seleccione Carrera";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Registro,
            this.PromedioFinal,
            this.TituloHonorificoAsignado});
            this.dataGridView1.Location = new System.Drawing.Point(95, 165);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(552, 229);
            this.dataGridView1.TabIndex = 2;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Registro";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 125;
            // 
            // Registro
            // 
            this.Registro.HeaderText = "Nombre Completo";
            this.Registro.MinimumWidth = 6;
            this.Registro.Name = "Registro";
            this.Registro.Width = 125;
            // 
            // PromedioFinal
            // 
            this.PromedioFinal.HeaderText = "Promedio";
            this.PromedioFinal.MinimumWidth = 6;
            this.PromedioFinal.Name = "PromedioFinal";
            this.PromedioFinal.Width = 125;
            // 
            // TituloHonorificoAsignado
            // 
            this.TituloHonorificoAsignado.HeaderText = "Titulo Honorifico";
            this.TituloHonorificoAsignado.MinimumWidth = 6;
            this.TituloHonorificoAsignado.Name = "TituloHonorificoAsignado";
            this.TituloHonorificoAsignado.Width = 125;
            // 
            // Menu_Egresados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpReportes);
            this.Name = "Menu_Egresados";
            this.Text = "Menu_Egresados";
            this.grpReportes.ResumeLayout(false);
            this.grpReportes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCarrera;
        private System.Windows.Forms.GroupBox grpReportes;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.Label lblCarrera;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Registro;
        private System.Windows.Forms.DataGridViewTextBoxColumn PromedioFinal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TituloHonorificoAsignado;
    }
}