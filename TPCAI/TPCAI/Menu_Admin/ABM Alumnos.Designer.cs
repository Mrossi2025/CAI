namespace TPCAI
{
    partial class ABM_Alumnos
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
            this.grpDatosAlumno = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.lblDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.grpCarreras = new System.Windows.Forms.GroupBox();
            this.clbCarreras = new System.Windows.Forms.CheckedListBox();
            this.btnModificar = new System.Windows.Forms.Button();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.grpBuscarAlumno = new System.Windows.Forms.GroupBox();
            this.lblidAlumno = new System.Windows.Forms.Label();
            this.txtidAlumno = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVolver = new System.Windows.Forms.Button();
            this.btnCargarAlumnos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.grpDatosAlumno.SuspendLayout();
            this.grpCarreras.SuspendLayout();
            this.grpBuscarAlumno.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDatosAlumno
            // 
            this.grpDatosAlumno.Controls.Add(this.btnLimpiar);
            this.grpDatosAlumno.Controls.Add(this.btnEliminar);
            this.grpDatosAlumno.Controls.Add(this.lblDni);
            this.grpDatosAlumno.Controls.Add(this.txtDni);
            this.grpDatosAlumno.Controls.Add(this.btnAgregar);
            this.grpDatosAlumno.Controls.Add(this.grpCarreras);
            this.grpDatosAlumno.Controls.Add(this.btnModificar);
            this.grpDatosAlumno.Controls.Add(this.txtApellido);
            this.grpDatosAlumno.Controls.Add(this.lblApellido);
            this.grpDatosAlumno.Controls.Add(this.lblNombre);
            this.grpDatosAlumno.Controls.Add(this.txtNombre);
            this.grpDatosAlumno.Location = new System.Drawing.Point(41, 21);
            this.grpDatosAlumno.Name = "grpDatosAlumno";
            this.grpDatosAlumno.Size = new System.Drawing.Size(349, 407);
            this.grpDatosAlumno.TabIndex = 0;
            this.grpDatosAlumno.TabStop = false;
            this.grpDatosAlumno.Text = "Datos Alumno";
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(93, 379);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(122, 26);
            this.btnLimpiar.TabIndex = 13;
            this.btnLimpiar.Text = "Limpiar Datos";
            this.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(108, 331);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(96, 31);
            this.btnEliminar.TabIndex = 11;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // lblDni
            // 
            this.lblDni.AutoSize = true;
            this.lblDni.Location = new System.Drawing.Point(6, 115);
            this.lblDni.Name = "lblDni";
            this.lblDni.Size = new System.Drawing.Size(30, 16);
            this.lblDni.TabIndex = 3;
            this.lblDni.Text = "DNI";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(9, 134);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(221, 22);
            this.txtDni.TabIndex = 5;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(6, 331);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(96, 31);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // grpCarreras
            // 
            this.grpCarreras.Controls.Add(this.clbCarreras);
            this.grpCarreras.Location = new System.Drawing.Point(6, 162);
            this.grpCarreras.Name = "grpCarreras";
            this.grpCarreras.Size = new System.Drawing.Size(244, 149);
            this.grpCarreras.TabIndex = 9;
            this.grpCarreras.TabStop = false;
            this.grpCarreras.Text = "Carreras";
            // 
            // clbCarreras
            // 
            this.clbCarreras.FormattingEnabled = true;
            this.clbCarreras.Items.AddRange(new object[] {
            "Carrera 1",
            "Carrera 2",
            "Carrera 3",
            "Carrera 4",
            "Carrera 5",
            "Carrera 6"});
            this.clbCarreras.Location = new System.Drawing.Point(6, 21);
            this.clbCarreras.Name = "clbCarreras";
            this.clbCarreras.Size = new System.Drawing.Size(219, 106);
            this.clbCarreras.TabIndex = 8;
            this.clbCarreras.Enter += new System.EventHandler(this.clbCarreras_Enter);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(210, 331);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(96, 31);
            this.btnModificar.TabIndex = 12;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(9, 86);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(221, 22);
            this.txtApellido.TabIndex = 4;
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Location = new System.Drawing.Point(6, 67);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(57, 16);
            this.lblApellido.TabIndex = 2;
            this.lblApellido.Text = "Apellido";
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 23);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(9, 42);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(221, 22);
            this.txtNombre.TabIndex = 0;
            // 
            // grpBuscarAlumno
            // 
            this.grpBuscarAlumno.Controls.Add(this.lblidAlumno);
            this.grpBuscarAlumno.Controls.Add(this.txtidAlumno);
            this.grpBuscarAlumno.Controls.Add(this.btnBuscar);
            this.grpBuscarAlumno.Controls.Add(this.label4);
            this.grpBuscarAlumno.Location = new System.Drawing.Point(408, 23);
            this.grpBuscarAlumno.Name = "grpBuscarAlumno";
            this.grpBuscarAlumno.Size = new System.Drawing.Size(270, 125);
            this.grpBuscarAlumno.TabIndex = 1;
            this.grpBuscarAlumno.TabStop = false;
            this.grpBuscarAlumno.Text = "Buscar Alumno";
            // 
            // lblidAlumno
            // 
            this.lblidAlumno.AutoSize = true;
            this.lblidAlumno.Location = new System.Drawing.Point(6, 21);
            this.lblidAlumno.Name = "lblidAlumno";
            this.lblidAlumno.Size = new System.Drawing.Size(63, 16);
            this.lblidAlumno.TabIndex = 14;
            this.lblidAlumno.Text = "IdAlumno";
            // 
            // txtidAlumno
            // 
            this.txtidAlumno.Location = new System.Drawing.Point(9, 40);
            this.txtidAlumno.Name = "txtidAlumno";
            this.txtidAlumno.Size = new System.Drawing.Size(221, 22);
            this.txtidAlumno.TabIndex = 15;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(64, 68);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(111, 44);
            this.btnBuscar.TabIndex = 10;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 16);
            this.label4.TabIndex = 0;
            // 
            // btnVolver
            // 
            this.btnVolver.Location = new System.Drawing.Point(587, 340);
            this.btnVolver.Name = "btnVolver";
            this.btnVolver.Size = new System.Drawing.Size(123, 69);
            this.btnVolver.TabIndex = 13;
            this.btnVolver.Text = "Volver";
            this.btnVolver.UseVisualStyleBackColor = true;
            this.btnVolver.Click += new System.EventHandler(this.btnVolver_Click);
            // 
            // btnCargarAlumnos
            // 
            this.btnCargarAlumnos.Location = new System.Drawing.Point(472, 216);
            this.btnCargarAlumnos.Name = "btnCargarAlumnos";
            this.btnCargarAlumnos.Size = new System.Drawing.Size(138, 66);
            this.btnCargarAlumnos.TabIndex = 14;
            this.btnCargarAlumnos.Text = "Cargar Alumnos";
            this.btnCargarAlumnos.UseVisualStyleBackColor = true;
            this.btnCargarAlumnos.Click += new System.EventHandler(this.btnCargarAlumnos_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(396, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Presione para cargar la lista de alumnos en el sistema.";
            // 
            // ABM_Alumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCargarAlumnos);
            this.Controls.Add(this.btnVolver);
            this.Controls.Add(this.grpBuscarAlumno);
            this.Controls.Add(this.grpDatosAlumno);
            this.Name = "ABM_Alumnos";
            this.Text = "ABM Alumnos";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenuAdmin1_FormClosed);
            this.Load += new System.EventHandler(this.MenuAdmin1_Load);
            this.grpDatosAlumno.ResumeLayout(false);
            this.grpDatosAlumno.PerformLayout();
            this.grpCarreras.ResumeLayout(false);
            this.grpBuscarAlumno.ResumeLayout(false);
            this.grpBuscarAlumno.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDatosAlumno;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblDni;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.GroupBox grpBuscarAlumno;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpCarreras;
        private System.Windows.Forms.CheckedListBox clbCarreras;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnVolver;
        private System.Windows.Forms.Button btnCargarAlumnos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Label lblidAlumno;
        private System.Windows.Forms.TextBox txtidAlumno;
    }
}