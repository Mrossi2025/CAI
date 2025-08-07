using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_de_Negocios;
using Datos;


namespace TPCAI
{
    public partial class ABM_Docentes : Form
    {
        MenuAdmin MenuAdmin2 = new MenuAdmin();

        public List<Docente> listaDocentes = new List<Docente>();
        List<CarrerasResponse> Carreras = new List<CarrerasResponse>();
        

        public ABM_Docentes(MenuAdmin menuAdmin2)
        {
            InitializeComponent();
            MenuAdmin2 = menuAdmin2;
        }

        private void ABM_Docentes_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuAdmin2.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAdmin2.Show();
        }

        private void btnCargarDocentes_Click(object sender, EventArgs e)
        {

            try
            {
                ListaDocentes lst = new ListaDocentes();
                listaDocentes = lst.ObtenerListaDocentes();
                MessageBox.Show($"Lista cargada: hay {listaDocentes.Count} docentes.");


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



        }

        private bool carrerasCargadas = false;

        private void ABM_Docentes_Load(object sender, EventArgs e)
        {
            try
            {
                // Cargar carreras
                CargarCarreras cc = new CargarCarreras();
                Carreras = cc.cargarCarreras();

                //Asignar data al ComboBox
                cmbCarreras.DataSource = Carreras;
                cmbCarreras.DisplayMember = "nombre"; 
                cmbCarreras.ValueMember = "id";       

                carrerasCargadas = true; //habilitamos la carga de materias

                cmbCarreras.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las carreras", ex.ToString());
            }


            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtCUIT.ReadOnly = true;
            txtDni.ReadOnly = true;
            txtCUIT2.ReadOnly = true;
            txtTipoDocente.ReadOnly = true;
            txtAntiguedad.ReadOnly = true;  


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Docente Busqueda = new Docente();
            float IdDocente;

            
            if (!float.TryParse(txtIdDocente.Text, out IdDocente))
            { MessageBox.Show("El Id debe ser númerico."); }
            else if (IdDocente < 0)
            { MessageBox.Show("El ID no puede ser negativo"); return; }
            else
            {

                if (listaDocentes.Count == 0)
                { MessageBox.Show("Debe cargar la lista de Docentes primero."); return; }


                foreach (Docente d in listaDocentes)
                {

                    Busqueda = listaDocentes.Find(a => a.id == IdDocente);

                }

                if (Busqueda == null) { MessageBox.Show("No se ha encontrado un Docente con ese Id."); }

                else
                {

                    txtNombre.Text = Busqueda.nombre;
                    txtApellido.Text = Busqueda.apellido;
                    if (!string.IsNullOrEmpty(Busqueda.cuit) && Busqueda.cuit.Count(c => c == '-') == 2) //Validamos el formato del CUIT.
                    {
                        string[] partes = Busqueda.cuit.Split('-');
                        txtCUIT.Text = partes.Length > 0 ? partes[0] : "";
                        txtCUIT2.Text = partes.Length > 1 ? partes[2] : ""; //Va un 2 porque el cuit lo separa en 3 partes, el 1 es el DNI.
                        
                    }
                    else
                    {
                        // CUIT vacío o con formato inválido → lo dejamos en blanco
                        txtCUIT.Text = "";
                        txtCUIT2.Text = "";
                        
                    }
                    txtDni.Text = Busqueda.dni;
                    txtAntiguedad.Text = Busqueda.antiguedad.ToString(); //(No es necesaria esta info aca)
                    txtTipoDocente.Text = Busqueda.tipo;

                    MessageBox.Show("Docente encontrado.");
                }


            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            bool hayCamposIncompletos = false;

            // Validación campo por campo
            if (string.IsNullOrWhiteSpace(txtNombreAgregardocente.Text))
            {
                txtNombreAgregardocente.BackColor = Color.LightBlue;
                hayCamposIncompletos = true;
            }
            if (string.IsNullOrWhiteSpace(txtApellidoAgregarDocente.Text))
            {
                txtApellidoAgregarDocente.BackColor = Color.LightBlue;
                hayCamposIncompletos = true;
            }
            if (string.IsNullOrWhiteSpace(txtCuitAgregarDocente.Text))
            {
                txtCuitAgregarDocente.BackColor = Color.LightBlue;
                hayCamposIncompletos = true;
            }
            if (string.IsNullOrWhiteSpace(txtDniAgregarDocente.Text))
            {
                txtDniAgregarDocente.BackColor = Color.LightBlue;
                hayCamposIncompletos = true;
            }
            if (string.IsNullOrWhiteSpace(txtCuitAgregarDocente2.Text))
            {
                txtCuitAgregarDocente2.BackColor = Color.LightBlue;
                hayCamposIncompletos = true;
            }
            if (cmbCargoDocenteNuevo.SelectedItem == null)
            {
                cmbCargoDocenteNuevo.BackColor = Color.LightBlue;
                hayCamposIncompletos = true;
            }

            if (hayCamposIncompletos)
            {
                MessageBox.Show("Complete todos los campos antes de continuar.");
                return;
            }



            if (!int.TryParse(txtCuitAgregarDocente.Text, out int CuitParte1) ||
                !int.TryParse(txtCuitAgregarDocente2.Text, out int CuitParte2) || 
                !int.TryParse(txtDniAgregarDocente.Text, out int dniNumerico))
            { MessageBox.Show("El CUIT ingresdo es invalido, por favor verifique que sea numerico"); return; }

            if(!string.IsNullOrWhiteSpace(txtIdDocenteNuevo.Text))
            { MessageBox.Show("El ID Docente no es necesario en la función agregar, por favor borrelo."); return; }

            string cuitConcatenado = txtCuitAgregarDocente.Text + "-" + txtDniAgregarDocente.Text + "-" + txtCuitAgregarDocente2.Text;

            if (cuitConcatenado.Length > 13 || cuitConcatenado.Length < 12)
            { MessageBox.Show("El CUIT ingresdo es invalido, por favor verifique la longitud"); return; }

            if (txtNombreAgregardocente.Text.Any(char.IsDigit))
            {Console.WriteLine("El Nombre no puede contener números."); return;}
            if (txtApellidoAgregarDocente.Text.Any(char.IsDigit))
            { Console.WriteLine("El Apellido no puede contener números."); return; }

            if(listaDocentes.Count == 0)
            { MessageBox.Show("Debe cargar la lista de docentes primero."); return; }

            if (clbCursos.CheckedItems == null || clbCursos.CheckedItems.Count == 0)
            {
                DialogResult result = MessageBox.Show(
                    "No ha seleccionado ningún curso.\n¿Desea continuar de todas formas sin asignar cursos?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    return; // Sale del método y no continúa
                }
            }


            string apellido = txtApellidoAgregarDocente.Text;
            string nombre = txtNombreAgregardocente.Text;
            string tipo = cmbCargoDocenteNuevo.SelectedItem.ToString();
            string dni = txtDniAgregarDocente.Text;
            





            foreach (Docente d in listaDocentes)
            {
                if (d.dni == dni)
                { MessageBox.Show("El docente/ayudante que desea ingresar, ya esta registrado en el sistema."); return; }

            }


            AgregarDocente a = new AgregarDocente();
            List<long> lista = new List<long>();

            if (clbCursos.CheckedItems == null || clbCursos.CheckedItems.Count == 0)
            { lista.Add(0);

                string Respuesta = a.CargarDocente(nombre, apellido, cuitConcatenado, dni, tipo, lista);

                if (Respuesta == "OK")
                {
                    ListaDocentes lst = new ListaDocentes();

                    try
                    {

                        listaDocentes = lst.ObtenerListaDocentes();
                        

                        Docente docenteAgregado = listaDocentes.Find(b => b.dni == txtDniAgregarDocente.Text);

                        MessageBox.Show($"Docente añadido con exito (id: {docenteAgregado.id}.) \n Lista actualizada: Hay {listaDocentes.Count} alumnos.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdDocenteNuevo.Text = docenteAgregado.id.ToString();


                    }
                    catch (Exception ex) { MessageBox.Show("Docente agregado exitosamente, pero ha ocurrido un error actualizando la lista, por favor cargar nuevamente.", ex.ToString()); }

                }
                else { MessageBox.Show("Ha ocurrido un error, intente nuevamente.", Respuesta); }

            }
            else
            {
                foreach (Cursos cursos in clbCursos.CheckedItems)
                {
                    lista.Add(cursos.id);
                }


                string Respuesta = a.CargarDocente(nombre, apellido, cuitConcatenado, dni, tipo, lista);

                if (Respuesta == "OK")
                {
                    ListaDocentes lst = new ListaDocentes();

                    try
                    {

                        listaDocentes = lst.ObtenerListaDocentes();
                        Docente docenteAgregado = listaDocentes.Find(b => b.dni == txtDniAgregarDocente.Text);

                        MessageBox.Show($"Docente añadido con exito (id: {docenteAgregado.id}.) \n Lista actualizada: Hay {listaDocentes.Count} docentes.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIdDocenteNuevo.Text = docenteAgregado.id.ToString();


                    }
                    catch (Exception ex) { MessageBox.Show("Docente agregado exitosamente, pero ha ocurrido un error actualizando la lista, por favor cargar nuevamente.",ex.ToString()); }

                }
                else { MessageBox.Show("Ha ocurrido un error, intente nuevamente.", Respuesta); }

            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCUIT.Clear();
            txtCUIT2.Clear();
            txtDni.Clear();
            txtAntiguedad.Clear();
            txtTipoDocente.Clear();

        }

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            txtIdDocenteNuevo.Clear();
            txtNombreAgregardocente.Clear();
            txtApellidoAgregarDocente.Clear();
            txtCuitAgregarDocente.Clear();
            txtDniAgregarDocente.Clear();
            txtCuitAgregarDocente2.Clear();
            cmbCargoDocenteNuevo.SelectedIndex = -1;
            cmbMaterias.DataSource = null;
            cmbCarreras.SelectedIndex = -1;
        }



        private void txtNombreAgregardocente_Enter(object sender, EventArgs e)
        {
            txtNombreAgregardocente.BackColor = Color.White;
        }

        private void txtApellidoAgregarDocente_Enter(object sender, EventArgs e)
        {
            txtApellidoAgregarDocente.BackColor = Color.White;
        }

        private void txtCuitAgregarDocente_Enter(object sender, EventArgs e)
        {
            txtCuitAgregarDocente.BackColor = Color.White;
        }

        private void txtDniAgregarDocente_Enter(object sender, EventArgs e)
        {
            txtDniAgregarDocente.BackColor = Color.White;
        }

       

        private void cmbCargoDocenteNuevo_Enter(object sender, EventArgs e)
        {
            cmbCargoDocenteNuevo.BackColor = Color.White;
        }

        

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool hayIncompletos = false;

            if (string.IsNullOrWhiteSpace(txtIdDocenteNuevo.Text))
            {
                txtIdDocente.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }


            if (string.IsNullOrWhiteSpace(txtNombreAgregardocente.Text))
            {
                txtNombre.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (string.IsNullOrWhiteSpace(txtApellidoAgregarDocente.Text))
            {
                txtApellido.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (string.IsNullOrWhiteSpace(txtCuitAgregarDocente.Text))
            {
                txtCUIT.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (string.IsNullOrWhiteSpace(txtCuitAgregarDocente2.Text))
            {
                txtCUIT2.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (string.IsNullOrWhiteSpace(txtDniAgregarDocente.Text))
            {
                txtDni.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (cmbCargoDocenteNuevo.SelectedItem == null)
            {
                cmbCargoDocenteNuevo.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }


                if (hayIncompletos)
                {
                    MessageBox.Show("Debe completar todos los campos de la seccion Datos Docente y el Id Docente.");
                    return;
                }


                
                if (!long.TryParse(txtIdDocenteNuevo.Text, out long id))
                { MessageBox.Show("Debe ingresar un numero de curso válido"); return; } //Valido que sea numerico el id
                if(id < 0)
                { MessageBox.Show("El ID docente no puede ser un número negativo."); return; }
                if (!int.TryParse(txtCuitAgregarDocente.Text, out int CuitParte1) ||
                    !int.TryParse(txtCuitAgregarDocente2.Text, out int CuitParte2) ||
                    !int.TryParse(txtDniAgregarDocente.Text, out int dniNumerico))
                { MessageBox.Show("El CUIT ingresdo es invalido, por favor verifique que sea numerico"); return; }

                string cuitConcatenado = txtCuitAgregarDocente.Text + "-" + txtDniAgregarDocente.Text + "-" + txtCuitAgregarDocente2.Text;
                                            //va +2 por los - que concateno
                if (cuitConcatenado.Length > 11+2 || cuitConcatenado.Length < 10+2)
                { MessageBox.Show("El CUIT ingresdo es invalido, por favor verifique la longitud"); return; }
                if (txtNombreAgregardocente.Text.Any(char.IsDigit))
                { Console.WriteLine("El Nombre no puede contener números."); return; }
                if (txtApellidoAgregarDocente.Text.Any(char.IsDigit))
                { Console.WriteLine("El Apellido no puede contener números."); return; }

            if (clbCursos.CheckedItems == null || clbCursos.CheckedItems.Count == 0)
            {
                DialogResult result = MessageBox.Show(
                    "No ha seleccionado ningún curso.\n¿Desea continuar de todas formas sin asignar cursos?",
                    "Confirmación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.No)
                {
                    return; // Sale del método y no continúa
                }
            }


                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string dni = txtDni.Text;
                string tipo = cmbCargoDocenteNuevo.SelectedItem.ToString();
                


                ActualizarDocenteNegocio a = new ActualizarDocenteNegocio();
                List<long> listaCursos = new List<long>();

            if (clbCursos.CheckedItems == null || clbCursos.CheckedItems.Count == 0)
            {   
                listaCursos.Add(0);



                string Respuesta = a.ActualizarDocente(nombre, apellido, cuitConcatenado, dni, tipo, listaCursos, id);

                if (Respuesta == "OK")
                {
                    ListaDocentes lst = new ListaDocentes();

                    try
                    {

                        listaDocentes = lst.ObtenerListaDocentes();
                        MessageBox.Show($"Docente Actualizado: hay {listaDocentes.Count} docentes.");


                    }
                    catch (Exception ex) { MessageBox.Show("Error actualizando la lista docentes, refresque la lista.",ex.ToString()); }
                }
                else { MessageBox.Show("Ha ocurrido un error, intente nuevamente.", Respuesta); }

            }
            else
            {
                foreach (Cursos cursos in clbCursos.CheckedItems)
                {
                    listaCursos.Add(cursos.id);
                }


                string Respuesta = a.ActualizarDocente(nombre, apellido, cuitConcatenado, dni, tipo, listaCursos, id);

                if (Respuesta == "OK")
                {
                    ListaDocentes lst = new ListaDocentes();

                    try
                    {

                        listaDocentes = lst.ObtenerListaDocentes();
                        MessageBox.Show($"Docente Actualizado: hay {listaDocentes.Count} docentes.");


                    }
                    catch (Exception ex) { MessageBox.Show("Error actualizando la lista docentes, refresque la lista.",ex.ToString()); }
                }
                else { MessageBox.Show("Ha ocurrido un error, intente nuevamente.", Respuesta); }



            }
            


        }

        

        private void txtIdDocente_Enter(object sender, EventArgs e)
        {
            txtIdDocente.BackColor = Color.White;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            long IdDocente;

            if(string.IsNullOrWhiteSpace(txtIdDocente.Text))
            { MessageBox.Show("Debe ingresar un Id a Eliminar"); txtIdDocente.BackColor = Color.LightBlue; return; }
            if (!long.TryParse(txtIdDocente.Text, out IdDocente))
            { MessageBox.Show("El id ingresado debe ser númerico."); return; }
            if (IdDocente < 0)
            { MessageBox.Show("El ID docente no puede ser un número negativo."); return; }
            if (listaDocentes.Count == 0)            
            { MessageBox.Show("Debe cargar la lista de docentes antes de eliminar."); return; }
            if(listaDocentes.Find(ab => ab.id == IdDocente) ==null)
            { MessageBox.Show("El Id Ingresado no existe en la lista de docentes. Pruebe otro."); return; }


                DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro que querés continuar?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
            {
                // Si presionó "No", se cancela
                return;
            }

            EliminarDocenteNegocio a = new EliminarDocenteNegocio();

            string Respuesta = a.EliminarDocente(IdDocente);
            if (Respuesta == "OK")
            {
                try
                {
                    ListaDocentes lst = new ListaDocentes();
                    listaDocentes = lst.ObtenerListaDocentes();
                    MessageBox.Show($"Docente eliminado exitosamente, actualmente hay {listaDocentes.Count} docentes registrados.");


                }
                catch (Exception ex) { MessageBox.Show("Docente eliminado exitosamente, pero ha ocurrido un error actualizando la lista docentes. (Carguela Nuevamente)",ex.ToString()); }
            }
            else { MessageBox.Show("Ha ocurrido un error, intente nuevamente.", Respuesta); }
        }

        private void btnEliminar_Enter(object sender, EventArgs e)
        {
            txtIdDocente.BackColor = Color.White;
        }

        private void txtCuitAgregarDocente2_Enter(object sender, EventArgs e)
        {
            txtCuitAgregarDocente2.BackColor = Color.White;

        }

        private void txtCUIT2_Enter(object sender, EventArgs e)
        {
            txtCUIT2.BackColor = Color.White;
        }

        private bool materiasCargadas = false;
        private void cmbCarreras_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1️ Evitar que corra durante la carga inicial
            if (!carrerasCargadas) return;

            // 2️ Verificar que el SelectedValue no sea null
            if (cmbCarreras.SelectedValue == null)
                return;

            // 3️ Obtener carreraId de forma segura
            if (!long.TryParse(cmbCarreras.SelectedValue.ToString(), out long carreraId))
                return;

            try
            {
                // 4️ Llamar a negocio y cargar materias
                CargarMateriasNegocio cmn = new CargarMateriasNegocio();
                List<Materias> materias = cmn.CargarMaterias(carreraId);

                cmbMaterias.DataSource = materias;
                cmbMaterias.DisplayMember = "nombre";
                cmbMaterias.ValueMember = "id";
                materiasCargadas = true; //habilitamos la carga de cursos
                cmbMaterias.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando las materias de la carrera seleccionada", ex.ToString());
            }
        }


        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  Evitar que corra durante la carga inicial de materias
            if (!materiasCargadas) return;

            //  Verificar que el SelectedValue no sea null
            if (cmbMaterias.SelectedValue == null)
                return;

            //  Obtener materiaId de forma segura
            if (!long.TryParse(cmbMaterias.SelectedValue.ToString(), out long materiaId))
                return;

            try
            {
                // Cargar cursos desde negocio
                CargarCursosNegocio ccn = new CargarCursosNegocio();
                List<Cursos> cursos = ccn.CargarCursos(materiaId);

                // Enlazar cursos al checklist
                clbCursos.DataSource = cursos;
                clbCursos.DisplayMember = "profesorNombre"; // Ponemos el nombre del titular del curso
                clbCursos.ValueMember = "id";

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando los cursos de la materia seleccionada", ex.ToString());
            }
        }

        private void cmbMaterias_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(cmbMaterias.Text))
            {
                clbCursos.DataSource = null; // Limpia la lista de cursos
            }
        }

        private void clbCursos_Enter(object sender, EventArgs e)
        {
            clbCursos.BackColor = Color.White;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(txtNombre.Text) ||
               string.IsNullOrWhiteSpace(txtApellido.Text) ||
               string.IsNullOrWhiteSpace(txtAntiguedad.Text))
            {
                MessageBox.Show("Debe buscar un docente primero, ingrese su id y presione buscar."); return;
            }

            txtIdDocenteNuevo.Text = txtIdDocente.Text;
            txtNombreAgregardocente.Text = txtNombre.Text;
            txtApellidoAgregarDocente.Text = txtApellido.Text;
            txtIdDocenteNuevo.Text = txtIdDocente.Text;
            txtCuitAgregarDocente.Text = txtCUIT.Text;
            txtDniAgregarDocente.Text = txtDni.Text;
            txtCuitAgregarDocente2.Text = txtCUIT2.Text;

            if (txtTipoDocente.Text == "PROFESOR")
            { cmbCargoDocenteNuevo.SelectedIndex = 0; }
            else if (txtTipoDocente.Text == "AYUDANTE")
            { cmbCargoDocenteNuevo.SelectedIndex = 1; }
            else if (txtTipoDocente.Text == "AYUDANTE_AD_HONOREM")
            { cmbCargoDocenteNuevo.SelectedIndex = 2; }

            MessageBox.Show("Datos pasados correctamente al menú para modificar");




        }
    }
    
}
