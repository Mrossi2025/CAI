namespace TPCAI
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
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
            this.grpSystemLogin = new System.Windows.Forms.GroupBox();
            this.btnIniciarSesion = new System.Windows.Forms.Button();
            this.txtConstraseña = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblContraseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.grpSystemLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSystemLogin
            // 
            this.grpSystemLogin.Controls.Add(this.btnIniciarSesion);
            this.grpSystemLogin.Controls.Add(this.txtConstraseña);
            this.grpSystemLogin.Controls.Add(this.txtUsuario);
            this.grpSystemLogin.Controls.Add(this.lblContraseña);
            this.grpSystemLogin.Controls.Add(this.lblUsuario);
            this.grpSystemLogin.Location = new System.Drawing.Point(9, 18);
            this.grpSystemLogin.Margin = new System.Windows.Forms.Padding(2);
            this.grpSystemLogin.Name = "grpSystemLogin";
            this.grpSystemLogin.Padding = new System.Windows.Forms.Padding(2);
            this.grpSystemLogin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grpSystemLogin.Size = new System.Drawing.Size(171, 232);
            this.grpSystemLogin.TabIndex = 0;
            this.grpSystemLogin.TabStop = false;
            this.grpSystemLogin.Text = "System Login";
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.Location = new System.Drawing.Point(12, 124);
            this.btnIniciarSesion.Margin = new System.Windows.Forms.Padding(2);
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(84, 19);
            this.btnIniciarSesion.TabIndex = 4;
            this.btnIniciarSesion.Text = "Iniciar Sesión";
            this.btnIniciarSesion.UseVisualStyleBackColor = true;
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // txtConstraseña
            // 
            this.txtConstraseña.Location = new System.Drawing.Point(4, 92);
            this.txtConstraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txtConstraseña.Name = "txtConstraseña";
            this.txtConstraseña.Size = new System.Drawing.Size(102, 20);
            this.txtConstraseña.TabIndex = 3;
            this.txtConstraseña.Text = "password";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(4, 47);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(102, 20);
            this.txtUsuario.TabIndex = 2;
            this.txtUsuario.Text = "20458765";
            // 
            // lblContraseña
            // 
            this.lblContraseña.AutoSize = true;
            this.lblContraseña.Location = new System.Drawing.Point(2, 76);
            this.lblContraseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContraseña.Name = "lblContraseña";
            this.lblContraseña.Size = new System.Drawing.Size(61, 13);
            this.lblContraseña.TabIndex = 1;
            this.lblContraseña.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(3, 32);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(43, 13);
            this.lblUsuario.TabIndex = 0;
            this.lblUsuario.Text = "Usuario";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 366);
            this.Controls.Add(this.grpSystemLogin);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Login";
            this.Text = "VentanaLogin";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.VentanaLogin_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.grpSystemLogin.ResumeLayout(false);
            this.grpSystemLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSystemLogin;
        private System.Windows.Forms.Button btnIniciarSesion;
        private System.Windows.Forms.TextBox txtConstraseña;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblContraseña;
        private System.Windows.Forms.Label lblUsuario;
    }
}

