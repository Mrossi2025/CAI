namespace TPCAI
{
    partial class Liquidaciones
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtAntiguedad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rbtnAyudante = new System.Windows.Forms.RadioButton();
            this.rbtnProfesor = new System.Windows.Forms.RadioButton();
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHoras = new System.Windows.Forms.TextBox();
            this.btnLiquidar = new System.Windows.Forms.Button();
            this.btnVolver = new System.Windows.Forms.Button();
            this.cmbDocentes = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Personal a Liquidar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtAntiguedad);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.rbtnAyudante);
            this.groupBox1.Controls.Add(this.rbtnProfesor);
            this.groupBox1.Controls.Add(this.txtDNI);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtApellido);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(22, 61);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(262, 224);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Docente/Ayudante";
            // 
            // txtAntiguedad
            // 
            this.txtAntiguedad.Location = new System.Drawing.Point(12, 186);
            this.txtAntiguedad.Margin = new System.Windows.Forms.Padding(2);
            this.txtAntiguedad.Name = "txtAntiguedad";
            this.txtAntiguedad.Size = new System.Drawing.Size(108, 20);
            this.txtAntiguedad.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 171);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Antiguedad";
            // 
            // rbtnAyudante
            // 
            this.rbtnAyudante.AutoSize = true;
            this.rbtnAyudante.Location = new System.Drawing.Point(76, 150);
            this.rbtnAyudante.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnAyudante.Name = "rbtnAyudante";
            this.rbtnAyudante.Size = new System.Drawing.Size(70, 17);
            this.rbtnAyudante.TabIndex = 7;
            this.rbtnAyudante.TabStop = true;
            this.rbtnAyudante.Text = "Ayudante";
            this.rbtnAyudante.UseVisualStyleBackColor = true;
            // 
            // rbtnProfesor
            // 
            this.rbtnProfesor.AutoSize = true;
            this.rbtnProfesor.Location = new System.Drawing.Point(12, 150);
            this.rbtnProfesor.Margin = new System.Windows.Forms.Padding(2);
            this.rbtnProfesor.Name = "rbtnProfesor";
            this.rbtnProfesor.Size = new System.Drawing.Size(64, 17);
            this.rbtnProfesor.TabIndex = 6;
            this.rbtnProfesor.TabStop = true;
            this.rbtnProfesor.Text = "Profesor";
            this.rbtnProfesor.UseVisualStyleBackColor = true;
            // 
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(12, 120);
            this.txtDNI.Margin = new System.Windows.Forms.Padding(2);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(108, 20);
            this.txtDNI.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 105);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "DNI";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(12, 84);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(2);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(108, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Apellido";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(12, 47);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(108, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 32);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nombre";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 297);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(128, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Ingresar Horas a Liquidar:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // txtHoras
            // 
            this.txtHoras.Location = new System.Drawing.Point(156, 292);
            this.txtHoras.Margin = new System.Windows.Forms.Padding(2);
            this.txtHoras.Name = "txtHoras";
            this.txtHoras.Size = new System.Drawing.Size(130, 20);
            this.txtHoras.TabIndex = 4;
            // 
            // btnLiquidar
            // 
            this.btnLiquidar.Location = new System.Drawing.Point(81, 322);
            this.btnLiquidar.Margin = new System.Windows.Forms.Padding(2);
            this.btnLiquidar.Name = "btnLiquidar";
            this.btnLiquidar.Size = new System.Drawing.Size(126, 22);
            this.btnLiquidar.TabIndex = 5;
            this.btnLiquidar.Text = "Liquidar sueldo";
            this.btnLiquidar.UseVisualStyleBackColor = true;
            this.btnLiquidar.Click += new System.EventHandler(this.btnLiquidar_Click);
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(487, 292);
            this.btnVolver.Margin = new System.Windows.Forms.Padding(2);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(92, 56);
            this.btnVolver.TabIndex = 6;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // cmbDocentes
            // 
            this.cmbDocentes.FormattingEnabled = true;
            this.cmbDocentes.Location = new System.Drawing.Point(131, 29);
            this.cmbDocentes.Name = "cmbDocentes";
            this.cmbDocentes.Size = new System.Drawing.Size(121, 21);
            this.cmbDocentes.TabIndex = 7;
            // 
            // Liquidaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.cmbDocentes);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.btnLiquidar);
            this.Controls.Add(this.txtHoras);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Liquidaciones";
            this.Text = "Liquidaciones";
            this.Load += new System.EventHandler(this.Liquidaciones_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnProfesor;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAntiguedad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rbtnAyudante;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHoras;
        private System.Windows.Forms.Button btnLiquidar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.ComboBox cmbDocentes;
    }
}