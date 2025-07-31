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
            this.grpReportes = new System.Windows.Forms.GroupBox();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.btnReporte = new System.Windows.Forms.Button();
            this.grpReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // grpReportes
            // 
            this.grpReportes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpReportes.Controls.Add(this.dgvReporte);
            this.grpReportes.Controls.Add(this.btnReporte);
            this.grpReportes.Location = new System.Drawing.Point(12, 25);
            this.grpReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpReportes.Name = "grpReportes";
            this.grpReportes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpReportes.Size = new System.Drawing.Size(757, 414);
            this.grpReportes.TabIndex = 1;
            this.grpReportes.TabStop = false;
            this.grpReportes.Text = "Generar Reportes";
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(48, 85);
            this.dgvReporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.RowTemplate.Height = 24;
            this.dgvReporte.Size = new System.Drawing.Size(677, 229);
            this.dgvReporte.TabIndex = 2;
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(342, 19);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(103, 62);
            this.btnReporte.TabIndex = 2;
            this.btnReporte.Text = "Generar Reporte";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // Menu_Egresados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grpReportes);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Menu_Egresados";
            this.Text = "Menu_Egresados";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_Egresados_FormClosed);
            this.grpReportes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpReportes;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DataGridView dgvReporte;
    }
}