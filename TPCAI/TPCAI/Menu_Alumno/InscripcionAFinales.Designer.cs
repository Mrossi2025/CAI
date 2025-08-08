namespace TPCAI
{
    partial class InscripcionAFinales
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbFinales = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.lstFinalesInscriptos = new System.Windows.Forms.ListBox();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.lblFinales = new System.Windows.Forms.Label();
            this.lblInscriptos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblFinales
            // 
            this.lblFinales.AutoSize = true;
            this.lblFinales.Location = new System.Drawing.Point(20, 20);
            this.lblFinales.Name = "lblFinales";
            this.lblFinales.Size = new System.Drawing.Size(97, 13);
            this.lblFinales.TabIndex = 0;
            this.lblFinales.Text = "Finales pendientes:";
            // 
            // cmbFinales
            // 
            this.cmbFinales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFinales.FormattingEnabled = true;
            this.cmbFinales.Location = new System.Drawing.Point(20, 40);
            this.cmbFinales.Name = "cmbFinales";
            this.cmbFinales.Size = new System.Drawing.Size(300, 21);
            this.cmbFinales.TabIndex = 1;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(340, 40);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(100, 23);
            this.btnAgregar.TabIndex = 2;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // lblInscriptos
            // 
            this.lblInscriptos.AutoSize = true;
            this.lblInscriptos.Location = new System.Drawing.Point(20, 80);
            this.lblInscriptos.Name = "lblInscriptos";
            this.lblInscriptos.Size = new System.Drawing.Size(99, 13);
            this.lblInscriptos.TabIndex = 3;
            this.lblInscriptos.Text = "Finales inscriptos:";
            // 
            // lstFinalesInscriptos
            // 
            this.lstFinalesInscriptos.FormattingEnabled = true;
            this.lstFinalesInscriptos.Location = new System.Drawing.Point(20, 100);
            this.lstFinalesInscriptos.Name = "lstFinalesInscriptos";
            this.lstFinalesInscriptos.Size = new System.Drawing.Size(300, 95);
            this.lstFinalesInscriptos.TabIndex = 4;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.Location = new System.Drawing.Point(340, 100);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(100, 23);
            this.btnConfirmar.TabIndex = 5;
            this.btnConfirmar.Text = "Confirmar";
            this.btnConfirmar.UseVisualStyleBackColor = true;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(340, 172);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(100, 23);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // InscripcionAFinales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 220);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnConfirmar);
            this.Controls.Add(this.lstFinalesInscriptos);
            this.Controls.Add(this.lblInscriptos);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cmbFinales);
            this.Controls.Add(this.lblFinales);
            this.Name = "InscripcionAFinales";
            this.Text = "Inscripción a Finales";
            this.Load += new System.EventHandler(this.InscripcionAFinales_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox cmbFinales;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.ListBox lstFinalesInscriptos;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Label lblFinales;
        private System.Windows.Forms.Label lblInscriptos;
    }
}