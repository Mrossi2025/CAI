namespace TPCAI.Menu_Personal
{
    partial class MenuPersonal
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
            this.btnLiquidarSueldo = new System.Windows.Forms.Button();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnLiquidarSueldo
            // 
            this.btnLiquidarSueldo.Location = new System.Drawing.Point(58, 162);
            this.btnLiquidarSueldo.Name = "btnLiquidarSueldo";
            this.btnLiquidarSueldo.Size = new System.Drawing.Size(135, 57);
            this.btnLiquidarSueldo.TabIndex = 0;
            this.btnLiquidarSueldo.Text = "Liquidar Sueldo";
            this.btnLiquidarSueldo.UseVisualStyleBackColor = true;
            this.btnLiquidarSueldo.Click += new System.EventHandler(this.btnLiquidarSueldo_Click);
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBienvenida.Location = new System.Drawing.Point(79, 92);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(82, 17);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Cargando...";
            this.lblBienvenida.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(127, 260);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(113, 34);
            this.btnCerrarSesion.TabIndex = 2;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // MenuPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(252, 306);
            this.Controls.Add(this.btnCerrarSesion);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.btnLiquidarSueldo);
            this.Name = "MenuPersonal";
            this.Text = "MenuPersonal";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuPersonal_FormCLosed);
            this.Load += new System.EventHandler(this.Menu_Personal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLiquidarSueldo;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Button btnCerrarSesion;
    }
}