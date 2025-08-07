namespace TPCAI
{
    partial class MenuPrincipalAlumno
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
            this.btnInscribirte = new System.Windows.Forms.Button();
            this.grpMenuAlumnos = new System.Windows.Forms.GroupBox();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSeleccione = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.grpMenuAlumnos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInscribirte
            // 
            this.btnInscribirte.Location = new System.Drawing.Point(32, 92);
            this.btnInscribirte.Margin = new System.Windows.Forms.Padding(2);
            this.btnInscribirte.Name = "btnInscribirte";
            this.btnInscribirte.Size = new System.Drawing.Size(136, 55);
            this.btnInscribirte.TabIndex = 1;
            this.btnInscribirte.Text = "Inscripciónes";
            this.btnInscribirte.UseVisualStyleBackColor = true;
            this.btnInscribirte.Click += new System.EventHandler(this.btnInscribirte_Click);
            // 
            // grpMenuAlumnos
            // 
            this.grpMenuAlumnos.Controls.Add(this.btnCerrarSesion);
            this.grpMenuAlumnos.Controls.Add(this.button2);
            this.grpMenuAlumnos.Controls.Add(this.lblSeleccione);
            this.grpMenuAlumnos.Controls.Add(this.btnInscribirte);
            this.grpMenuAlumnos.Location = new System.Drawing.Point(9, 58);
            this.grpMenuAlumnos.Margin = new System.Windows.Forms.Padding(2);
            this.grpMenuAlumnos.Name = "grpMenuAlumnos";
            this.grpMenuAlumnos.Padding = new System.Windows.Forms.Padding(2);
            this.grpMenuAlumnos.Size = new System.Drawing.Size(473, 233);
            this.grpMenuAlumnos.TabIndex = 2;
            this.grpMenuAlumnos.TabStop = false;
            this.grpMenuAlumnos.Text = "Menú Alumnos";
            this.grpMenuAlumnos.Enter += new System.EventHandler(this.grpMenuAlumnos_Enter);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(312, 92);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(136, 55);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(172, 91);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(136, 55);
            this.button2.TabIndex = 4;
            this.button2.Text = "Calculo de Ranking";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblSeleccione
            // 
            this.lblSeleccione.AutoSize = true;
            this.lblSeleccione.Location = new System.Drawing.Point(22, 52);
            this.lblSeleccione.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSeleccione.Name = "lblSeleccione";
            this.lblSeleccione.Size = new System.Drawing.Size(63, 13);
            this.lblSeleccione.TabIndex = 2;
            this.lblSeleccione.Text = "Seleccione:";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(123, 17);
            this.lblBienvenida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(70, 13);
            this.lblBienvenida.TabIndex = 3;
            this.lblBienvenida.Text = "lblBienvenida";
            // 
            // Menu_principal___Alumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 366);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.grpMenuAlumnos);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Menu_principal___Alumno";
            this.Text = "Menu_principal___Alumno";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuPrincipalAlumno_FormClosed);
            this.grpMenuAlumnos.ResumeLayout(false);
            this.grpMenuAlumnos.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnInscribirte;
        private System.Windows.Forms.GroupBox grpMenuAlumnos;
        private System.Windows.Forms.Label lblSeleccione;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Label lblBienvenida;
    }
}