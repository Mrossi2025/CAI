using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Capa_de_Negocios;

namespace TPCAI
{
    

    public partial class MenuAdmin1 : Form
    {

        List<Alumnos> listaAlumnos = new List<Alumnos>(); //Declaro la lista donde se van a guardar
        List<CarrerasResponse> Carreras = new List<CarrerasResponse>();


        private MenuAdmin menuAdmin;
        

        public MenuAdmin1()
        {
            InitializeComponent();
        }

        public MenuAdmin1(MenuAdmin Volver)
        {
            InitializeComponent();
            menuAdmin = Volver;

            



        }

        private void btnVolver_Click(object sender, EventArgs e)
        {

            this.Close();
            menuAdmin.Show();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            
            Alumnos alumnoAbuscar;

            alumnoAbuscar = listaAlumnos.Find(d => d.dni == txtDni.Text.Trim());

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            { MessageBox.Show("El campo DNI no puede estar vacío ingrese uno..."); }
            else if (listaAlumnos.Count == 0)
            { MessageBox.Show("Debe cargar la lista de alumnos"); }
            else if (alumnoAbuscar == null)
            //El return de aca es para que entre ahi y que no siga con el resto del codigo.
            { MessageBox.Show("No se encontró un alumno con ese DNI"); return; }
            else
            {
                txtNombre.Text = alumnoAbuscar.nombre;
                txtApellido.Text = alumnoAbuscar.apellido;

                // a) Primero desmarca todo para empezar limpio
                for (int i = 0; i < clbCarreras.Items.Count; i++)
                    clbCarreras.SetItemChecked(i, false);

                // b) Luego marca solo los Ids que el alumno tiene
                //    Recorremos por índice para poder llamar SetItemChecked
                for (int i = 0; i < clbCarreras.Items.Count; i++)
                {
                    // Cada ítem es CarrerasResponse porque fue el DataSource
                    var carrera = (CarrerasResponse)clbCarreras.Items[i];

                    if (alumnoAbuscar.carrerasIds.Contains(carrera.id))
                        clbCarreras.SetItemChecked(i, true);
                }

                MessageBox.Show("Alumno encontrado con exito");

            }


            



        }


                
                
            private void btnCargarAlumnos_Click(object sender, EventArgs e)
            {
            try
            {
                 ListaAlumnos listaAllamar = new ListaAlumnos(); //Instancio la clase de Negocio que contiene el metodo a llamar

                listaAlumnos = listaAllamar.TraerAlumnos();

                int cantidad = listaAlumnos.Count;   // si es null → 0
                MessageBox.Show($"Se han cargado con exito {cantidad} alumnos", "Exito",MessageBoxButtons.OK,MessageBoxIcon.Information);

                if (listaAlumnos == null || listaAlumnos.Count == 0)
                {
                    MessageBox.Show("La lista de alumnos está vacía.");
                    return;
                }


            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error al traer alumnos"); }

            }

            

        private void MenuAdmin1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            menuAdmin.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            List<int> carrerasSeleccionadas = new List<int>();

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string DNI = txtDni.Text;

            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(apellido) || //Aca validamos que no esten vacias las variables del alumno que pasamos por referencia
                string.IsNullOrEmpty(DNI))
            {
                MessageBox.Show("Nombre, apellido y DNI son obligatorios.");
                return;
            }


            if (clbCarreras.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una carrera.");
                return;                                // corta el evento porque valida si hay alguna carrera seleccionada
            }


            foreach (var item in clbCarreras.CheckedItems) //Por cada seleccion en la checked list box...

            {
                switch (item)                 // ← compara el texto que ve el usuario
                {
                    case "Administración":
                        carrerasSeleccionadas.Add(1);    // id 1
                        break;

                    case "Actuario":
                        carrerasSeleccionadas.Add(2);    // id 2
                        break;

                    case "Contador":
                        carrerasSeleccionadas.Add(3);    // id 3
                        break;

                    case "Economía":
                        carrerasSeleccionadas.Add(4);    // id 4
                        break;

                    case "Sistemas":
                        carrerasSeleccionadas.Add(5);    // id 5
                        break;

                    default:
                        MessageBox.Show($"Carrera no reconocida: {item}");
                        break;

                }

                Alumnos alumnoAregistrar = new Alumnos();

                alumnoAregistrar.nombre = nombre;
                alumnoAregistrar.apellido = apellido;
                alumnoAregistrar.dni = DNI;
                alumnoAregistrar.carrerasIds = carrerasSeleccionadas;

                
                AgregarAlumno nuevo = new AgregarAlumno();  
                string msj = nuevo.AgregarAlumnoNegocio(alumnoAregistrar);

                MessageBox.Show(msj );

            }   
        }

        private void MenuAdmin1_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCarreras cc = new CargarCarreras();
                Carreras = cc.cargarCarreras();

                clbCarreras.Items.Clear();
                foreach (CarrerasResponse carrera in Carreras)
                    clbCarreras.Items.Add(carrera.nombre);

            }

            catch (Exception ex) { MessageBox.Show("Error al cargar las carreras",ex.ToString()); }
        }

            private void btnLimpiar_Click(object sender, EventArgs e)
            {
                txtDni.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
            // Esto destilda todas las carreras
            for (int i = 0; i < clbCarreras.Items.Count; i++)
                clbCarreras.SetItemChecked(i, false);

            // (opcional) sacar también el resaltado
            clbCarreras.ClearSelected();

            }
    }
}
