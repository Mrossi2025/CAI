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
            this.btnFinales = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lblSeleccione = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.grpMenuAlumnos.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInscribirte
            // 
            this.btnInscribirte.Location = new System.Drawing.Point(53, 114);
            this.btnInscribirte.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInscribirte.Name = "btnInscribirte";
            this.btnInscribirte.Size = new System.Drawing.Size(125, 68);
            this.btnInscribirte.TabIndex = 1;
            this.btnInscribirte.Text = "Inscripcion a Materias";
            this.btnInscribirte.UseVisualStyleBackColor = true;
            this.btnInscribirte.Click += new System.EventHandler(this.btnInscribirte_Click);
            // 
            // grpMenuAlumnos
            // 
            this.grpMenuAlumnos.Controls.Add(this.btnFinales);
            this.grpMenuAlumnos.Controls.Add(this.btnCerrarSesion);
            this.grpMenuAlumnos.Controls.Add(this.button2);
            this.grpMenuAlumnos.Controls.Add(this.lblSeleccione);
            this.grpMenuAlumnos.Controls.Add(this.btnInscribirte);
            this.grpMenuAlumnos.Location = new System.Drawing.Point(12, 71);
            this.grpMenuAlumnos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpMenuAlumnos.Name = "grpMenuAlumnos";
            this.grpMenuAlumnos.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grpMenuAlumnos.Size = new System.Drawing.Size(631, 324);
            this.grpMenuAlumnos.TabIndex = 2;
            this.grpMenuAlumnos.TabStop = false;
            this.grpMenuAlumnos.Text = "Menú Alumnos";
            this.grpMenuAlumnos.Enter += new System.EventHandler(this.grpMenuAlumnos_Enter);
            // 
            // btnFinales
            // 
            this.btnFinales.Location = new System.Drawing.Point(187, 114);
            this.btnFinales.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnFinales.Name = "btnFinales";
            this.btnFinales.Size = new System.Drawing.Size(125, 68);
            this.btnFinales.TabIndex = 7;
            this.btnFinales.Text = "Inscripcion a finales";
            this.btnFinales.UseVisualStyleBackColor = true;
            this.btnFinales.Click += new System.EventHandler(this.btnFinales_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(451, 114);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(125, 68);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(317, 114);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(125, 68);
            this.button2.TabIndex = 4;
            this.button2.Text = "Calculo de Ranking";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnRanking);
            // 
            // lblSeleccione
            // 
            this.lblSeleccione.AutoSize = true;
            this.lblSeleccione.Location = new System.Drawing.Point(29, 64);
            this.lblSeleccione.Name = "lblSeleccione";
            this.lblSeleccione.Size = new System.Drawing.Size(78, 16);
            this.lblSeleccione.TabIndex = 2;
            this.lblSeleccione.Text = "Seleccione:";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Location = new System.Drawing.Point(164, 21);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(89, 16);
            this.lblBienvenida.TabIndex = 3;
            this.lblBienvenida.Text = "lblBienvenida";
            // 
            // MenuPrincipalAlumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 450);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.grpMenuAlumnos);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuPrincipalAlumno";
            this.Text = "Menu_principal___Alumno";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuPrincipalAlumno_FormClosed);
            this.Load += new System.EventHandler(this.MenuPrincipalAlumno_Load);
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
        private System.Windows.Forms.Button btnFinales;
    }
}