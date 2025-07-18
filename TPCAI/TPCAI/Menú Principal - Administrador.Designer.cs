namespace TPCAI
{
    partial class MenuAdmin
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
            this.grpMenuAdmin = new System.Windows.Forms.GroupBox();
            this.btnDesbloquearUsuario = new System.Windows.Forms.Button();
            this.btnEgresados = new System.Windows.Forms.Button();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnLiquidaciones = new System.Windows.Forms.Button();
            this.btmAbmDocentes = new System.Windows.Forms.Button();
            this.btnAbmAlumnos = new System.Windows.Forms.Button();
            this.grpMenuAdmin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMenuAdmin
            // 
            this.grpMenuAdmin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.grpMenuAdmin.Controls.Add(this.btnDesbloquearUsuario);
            this.grpMenuAdmin.Controls.Add(this.btnEgresados);
            this.grpMenuAdmin.Controls.Add(this.btnCerrarSesion);
            this.grpMenuAdmin.Controls.Add(this.btnLiquidaciones);
            this.grpMenuAdmin.Controls.Add(this.btmAbmDocentes);
            this.grpMenuAdmin.Controls.Add(this.btnAbmAlumnos);
            this.grpMenuAdmin.Location = new System.Drawing.Point(35, 24);
            this.grpMenuAdmin.Name = "grpMenuAdmin";
            this.grpMenuAdmin.Size = new System.Drawing.Size(340, 401);
            this.grpMenuAdmin.TabIndex = 0;
            this.grpMenuAdmin.TabStop = false;
            this.grpMenuAdmin.Text = "Menu Admin";
            // 
            // btnDesbloquearUsuario
            // 
            this.btnDesbloquearUsuario.Location = new System.Drawing.Point(83, 36);
            this.btnDesbloquearUsuario.Name = "btnDesbloquearUsuario";
            this.btnDesbloquearUsuario.Size = new System.Drawing.Size(173, 37);
            this.btnDesbloquearUsuario.TabIndex = 5;
            this.btnDesbloquearUsuario.Text = "Desbloquear Usuario";
            this.btnDesbloquearUsuario.UseVisualStyleBackColor = true;
            // 
            // btnEgresados
            // 
            this.btnEgresados.Location = new System.Drawing.Point(83, 255);
            this.btnEgresados.Name = "btnEgresados";
            this.btnEgresados.Size = new System.Drawing.Size(173, 44);
            this.btnEgresados.TabIndex = 4;
            this.btnEgresados.Text = "Egresados";
            this.btnEgresados.UseVisualStyleBackColor = true;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(83, 314);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(173, 44);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            // 
            // btnLiquidaciones
            // 
            this.btnLiquidaciones.Location = new System.Drawing.Point(83, 196);
            this.btnLiquidaciones.Name = "btnLiquidaciones";
            this.btnLiquidaciones.Size = new System.Drawing.Size(173, 44);
            this.btnLiquidaciones.TabIndex = 2;
            this.btnLiquidaciones.Text = "Liquidaciónes";
            this.btnLiquidaciones.UseVisualStyleBackColor = true;
            // 
            // btmAbmDocentes
            // 
            this.btmAbmDocentes.Location = new System.Drawing.Point(83, 140);
            this.btmAbmDocentes.Name = "btmAbmDocentes";
            this.btmAbmDocentes.Size = new System.Drawing.Size(173, 44);
            this.btmAbmDocentes.TabIndex = 1;
            this.btmAbmDocentes.Text = "ABM Docentes";
            this.btmAbmDocentes.UseVisualStyleBackColor = true;
            // 
            // btnAbmAlumnos
            // 
            this.btnAbmAlumnos.Location = new System.Drawing.Point(83, 88);
            this.btnAbmAlumnos.Name = "btnAbmAlumnos";
            this.btnAbmAlumnos.Size = new System.Drawing.Size(173, 37);
            this.btnAbmAlumnos.TabIndex = 0;
            this.btnAbmAlumnos.Text = "ABM Alumnos";
            this.btnAbmAlumnos.UseVisualStyleBackColor = true;
            // 
            // MenuAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 450);
            this.Controls.Add(this.grpMenuAdmin);
            this.Name = "MenuAdmin";
            this.Text = "Menu Principal - Administrador";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuAdmin_FormClosed);
            this.grpMenuAdmin.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMenuAdmin;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnLiquidaciones;
        private System.Windows.Forms.Button btmAbmDocentes;
        private System.Windows.Forms.Button btnAbmAlumnos;
        private System.Windows.Forms.Button btnEgresados;
        private System.Windows.Forms.Button btnDesbloquearUsuario;
    }
}