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
using Capa_de_Negocios.Menu_Admin.ABM_Docentes;
using Datos;
using Datos.Menu_Admin.ABM_DocentesClases;


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
            ListaDocentes lst = new ListaDocentes();



            try
            {

                listaDocentes = lst.ObtenerListaDocentes();
                MessageBox.Show($"Lista cargada: hay {listaDocentes.Count} docentes.");


            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }



        }

        private void ABM_Docentes_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCarreras cc = new CargarCarreras();
                Carreras = cc.cargarCarreras();

            }

            catch (Exception ex) { MessageBox.Show("Error al cargar las carreras", ex.ToString()); }







        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Docente Busqueda = new Docente();
            float IdDocente;

            
            if (!float.TryParse(txtIdDocente.Text, out IdDocente))
            { MessageBox.Show("El Id debe ser númerico."); }
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
                    string[] partes = Busqueda.cuit.Split('-'); //Separo el dato del cuit en 3 
                    txtCUIT.Text = partes[0];
                    txtCUIT2.Text = partes[2];
                    txtDni.Text = Busqueda.dni;
                    //  txtAntiguedad.Text = Busqueda.antiguedad.ToString(); (No es necesaria esta info aca)
                    cmbCargo.SelectedItem = Busqueda.tipo;

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
            if (string.IsNullOrWhiteSpace(txtCursoAgregarDocente.Text))
            {
                txtCursoAgregarDocente.BackColor = Color.LightBlue;
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

            string cuitConcatenado = txtCuitAgregarDocente.Text + "-" + txtDniAgregarDocente.Text + "-" + txtCuitAgregarDocente2.Text;

            if (cuitConcatenado.Length > 13 || cuitConcatenado.Length < 12)
            { MessageBox.Show("El CUIT ingresdo es invalido, por favor verifique la longitud"); return; }

            if (txtNombreAgregardocente.Text.Any(char.IsDigit))
            {Console.WriteLine("El Nombre no puede contener números."); return;}
            if (txtApellidoAgregarDocente.Text.Any(char.IsDigit))
            { Console.WriteLine("El Apellido no puede contener números."); return; }
            if (!long.TryParse(txtCursoAgregarDocente.Text, out long curso))
            { MessageBox.Show("Debe ingresar un numero de curso válido"); return; }


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
            lista.Add(curso);


            string Respuesta = a.CargarDocente(nombre, apellido, cuitConcatenado, dni, tipo, lista);

            if (Respuesta == "OK")
            {
                MessageBox.Show("Docente Agregado con exito. Actualice la lista para buscarlo.", Respuesta);
            }
            else { MessageBox.Show("Ha ocurrido un error, intente nuevamente.", Respuesta); }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCUIT.Clear();
            txtCUIT2.Clear();
            txtDni.Clear();
            //txtAntiguedad.Clear();
            cmbCargo.SelectedIndex = -1;
            txtCurso.Clear();

        }

        private void btnLimpiar2_Click(object sender, EventArgs e)
        {
            txtNombreAgregardocente.Clear();
            txtApellidoAgregarDocente.Clear();
            txtCuitAgregarDocente.Clear();
            txtDniAgregarDocente.Clear();
            txtCuitAgregarDocente2.Clear();
            cmbCargoDocenteNuevo.SelectedIndex = -1;
            txtCursoAgregarDocente.Clear();
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

        private void txtCursoAgregarDocente_Enter(object sender, EventArgs e)
        {
            txtCursoAgregarDocente.BackColor = Color.White;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool hayIncompletos = false;

            if (string.IsNullOrWhiteSpace(txtIdDocente.Text))
            {
                txtIdDocente.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }


            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                txtNombre.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                txtApellido.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (string.IsNullOrWhiteSpace(txtCUIT.Text))
            {
                txtCUIT.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (string.IsNullOrWhiteSpace(txtCUIT2.Text))
            {
                txtCUIT2.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                txtDni.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (cmbCargo.SelectedItem == null)
            {
                cmbCargo.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (string.IsNullOrWhiteSpace(txtCurso.Text))
            {
                txtCurso.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

                if (hayIncompletos)
                {
                    MessageBox.Show("Debe completar todos los campos de la seccion Datos Docente y el Id Docente.");
                    return;
                }


                if (!long.TryParse(txtCurso.Text, out long curso))
                { MessageBox.Show("Debe ingresar un numero de curso válido"); return; } //Valido que sea numerico el curso
                if (!long.TryParse(txtIdDocente.Text, out long id))
                { MessageBox.Show("Debe ingresar un numero de curso válido"); return; } //Valido que sea numerico el id
                if (!int.TryParse(txtCUIT.Text, out int CuitParte1) ||
                    !int.TryParse(txtCUIT2.Text, out int CuitParte2) ||
                    !int.TryParse(txtDni.Text, out int dniNumerico))
                { MessageBox.Show("El CUIT ingresdo es invalido, por favor verifique que sea numerico"); return; }

                string cuitConcatenado = txtCUIT.Text + "-" + txtDni.Text + "-" + txtCUIT2.Text;

                if (cuitConcatenado.Length > 13 || cuitConcatenado.Length < 12)
                { MessageBox.Show("El CUIT ingresdo es invalido, por favor verifique la longitud"); return; }
                if (txtNombreAgregardocente.Text.Any(char.IsDigit))
                { Console.WriteLine("El Nombre no puede contener números."); return; }
                if (txtApellidoAgregarDocente.Text.Any(char.IsDigit))
                { Console.WriteLine("El Apellido no puede contener números."); return; }

                string nombre = txtNombre.Text;
                string apellido = txtApellido.Text;
                string dni = txtDni.Text;
                string tipo = cmbCargo.SelectedItem.ToString();
                


            ActualizarDocenteNegocio a = new ActualizarDocenteNegocio();
                List<long> listaCursos = new List<long>();
                listaCursos.Add(curso);


                string Respuesta = a.ActualizarDocente(nombre, apellido, cuitConcatenado, dni, tipo, listaCursos, id);

                if (Respuesta == "OK")
                {
                    MessageBox.Show("Docente Actualizado con exito. Actualice la lista para buscarlo.", Respuesta);
                }
                else { MessageBox.Show("Ha ocurrido un error, intente nuevamente.", Respuesta); }   




            


        }

        private void txtCurso_Enter(object sender, EventArgs e)
        {
            txtCurso.BackColor = Color.White;
        }

        private void cmbCargo_Enter(object sender, EventArgs e)
        {
            cmbCargo.BackColor = Color.White;
        }

        private void txtDni_Enter(object sender, EventArgs e)
        {
            txtDni.BackColor = Color.White;
        }

        private void txtCUIT_Enter(object sender, EventArgs e)
        {
            txtCUIT.BackColor = Color.White;
        }
        


        private void txtApellido_Enter(object sender, EventArgs e)
        {
            txtApellido.BackColor = Color.White;
        }

        private void txtNombre_Enter(object sender, EventArgs e)
        {
            txtNombre.BackColor = Color.White;
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
            if (listaDocentes.Count == 0)            
            { MessageBox.Show("Debe cargar la lista de docentes antes de eliminar."); return; }
            if(listaDocentes.Find(ab => ab.id == IdDocente) ==null)
            { MessageBox.Show("El Id Ingresado no existe en la lista de docentes. Pruebe otro."); return; }


                DialogResult respuesta = MessageBox.Show(
                "¿Estás seguro que querés continuar?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
);

            if (respuesta != DialogResult.Yes)
            {
                // Si presionó "No", se cancela
                return;
            }

            EliminarDocenteNegocio a = new EliminarDocenteNegocio();

            string Respuesta = a.EliminarDocente(IdDocente);
            if (Respuesta == "OK")
            {
                MessageBox.Show("Docente Eliminado con exito. Actualice la lista para confirmarlo.", Respuesta);
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
    }
}
