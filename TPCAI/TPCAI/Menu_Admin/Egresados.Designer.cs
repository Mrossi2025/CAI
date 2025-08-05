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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvReporteGeneral = new System.Windows.Forms.DataGridView();
            this.btnVolver = new System.Windows.Forms.Button();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.btnReporte = new System.Windows.Forms.Button();
            this.grpReportes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteGeneral)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // grpReportes
            // 
            this.grpReportes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.grpReportes.Controls.Add(this.label2);
            this.grpReportes.Controls.Add(this.label1);
            this.grpReportes.Controls.Add(this.dgvReporteGeneral);
            this.grpReportes.Controls.Add(this.btnVolver);
            this.grpReportes.Controls.Add(this.dgvReporte);
            this.grpReportes.Controls.Add(this.btnReporte);
            this.grpReportes.Location = new System.Drawing.Point(12, 11);
            this.grpReportes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpReportes.Name = "grpReportes";
            this.grpReportes.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpReportes.Size = new System.Drawing.Size(1110, 428);
            this.grpReportes.TabIndex = 1;
            this.grpReportes.TabStop = false;
            this.grpReportes.Text = "Generar Reportes";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Reporte general";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(839, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Resumen del reporte";
            // 
            // dgvReporteGeneral
            // 
            this.dgvReporteGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporteGeneral.Location = new System.Drawing.Point(688, 42);
            this.dgvReporteGeneral.Name = "dgvReporteGeneral";
            this.dgvReporteGeneral.RowHeadersWidth = 51;
            this.dgvReporteGeneral.RowTemplate.Height = 24;
            this.dgvReporteGeneral.Size = new System.Drawing.Size(416, 308);
            this.dgvReporteGeneral.TabIndex = 3;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(1002, 362);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(103, 61);
            this.btnVolver.TabIndex = 2;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // dgvReporte
            // 
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(0, 42);
            this.dgvReporte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.RowTemplate.Height = 24;
            this.dgvReporte.Size = new System.Drawing.Size(616, 308);
            this.dgvReporte.TabIndex = 2;
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(257, 361);
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
            this.ClientSize = new System.Drawing.Size(1134, 450);
            this.Controls.Add(this.grpReportes);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Menu_Egresados";
            this.Text = "Menu_Egresados";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_Egresados_FormClosed);
            this.grpReportes.ResumeLayout(false);
            this.grpReportes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporteGeneral)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpReportes;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvReporteGeneral;
        private System.Windows.Forms.Label label2;
    }
}