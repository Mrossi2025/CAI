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
           

            



        }


                
                
            private void btnCargarAlumnos_Click(object sender, EventArgs e)
            {
            try
            {
                List<Alumnos> listaAlumnos = new List<Alumnos>(); //Declaro la lista donde se van a guardar
                ListaAlumnos listaAllamar = new ListaAlumnos(); //Instancio la clase de Negocio que contiene el metodo a llamar

                listaAlumnos = listaAllamar.TraerAlumnos();
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
                        carrerasSeleccionadas.Add(4);    // id 5
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
                List<CarrerasResponse> Carreras = cc.cargarCarreras();

                clbCarreras.Items.Clear();
                foreach (CarrerasResponse carrera in Carreras)
                    clbCarreras.Items.Add(carrera.nombre);

            }

            catch (Exception ex) { MessageBox.Show("Error al cargar las carreras",ex.ToString()); }
        }
    }
}
