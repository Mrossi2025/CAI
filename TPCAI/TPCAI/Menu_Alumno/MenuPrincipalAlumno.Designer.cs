namespace TPCAI
{
    partial class Menu_principal___Alumno
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
            this.btnInscribirte.Location = new System.Drawing.Point(42, 113);
            this.btnInscribirte.Name = "btnInscribirte";
            this.btnInscribirte.Size = new System.Drawing.Size(181, 68);
            this.btnInscribirte.TabIndex = 1;
            this.btnInscribirte.Text = "Inscripciónes";
            this.btnInscribirte.UseVisualStyleBackColor = true;
            // 
            // grpMenuAlumnos
            // 
            this.grpMenuAlumnos.Controls.Add(this.btnCerrarSesion);
            this.grpMenuAlumnos.Controls.Add(this.button2);
            this.grpMenuAlumnos.Controls.Add(this.lblSeleccione);
            this.grpMenuAlumnos.Controls.Add(this.btnInscribirte);
            this.grpMenuAlumnos.Location = new System.Drawing.Point(12, 71);
            this.grpMenuAlumnos.Name = "grpMenuAlumnos";
            this.grpMenuAlumnos.Size = new System.Drawing.Size(631, 287);
            this.grpMenuAlumnos.TabIndex = 2;
            this.grpMenuAlumnos.TabStop = false;
            this.grpMenuAlumnos.Text = "Menú Alumnos";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(416, 113);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(181, 68);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(229, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(181, 68);
            this.button2.TabIndex = 4;
            this.button2.Text = "Calculo de Ranking";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // lblSeleccione
            // 
            this.lblSeleccione.AutoSize = true;
            this.lblSeleccione.Location = new System.Drawing.Point(30, 64);
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
            // Menu_principal___Alumno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 450);
            this.Controls.Add(this.lblBienvenida);
            this.Controls.Add(this.grpMenuAlumnos);
            this.Name = "Menu_principal___Alumno";
            this.Text = "Menu_principal___Alumno";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Menu_principal___Alumno_FormClosed_1);
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