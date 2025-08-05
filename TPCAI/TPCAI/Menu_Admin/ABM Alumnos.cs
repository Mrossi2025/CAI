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
            long id;

            if (string.IsNullOrWhiteSpace(txtidAlumno.Text))
            { MessageBox.Show("El campo idAlumno no puede estar vacío ingrese uno..."); return; }
            if (!long.TryParse(txtidAlumno.Text, out id))
            { MessageBox.Show("El campo idAlumno debe ser númerico"); return; }
            if (id < 0)
            { MessageBox.Show("El ID no puede ser negativo"); return; }
            if (listaAlumnos.Count == 0)
            { MessageBox.Show("Debe cargar la lista de alumnos"); return; }

            Alumnos alumnoAbuscar;

            alumnoAbuscar = listaAlumnos.Find(d => d.id == id);

            
            if (alumnoAbuscar == null)
            //El return de aca es para que entre ahi y que no siga con el resto del codigo.
            { MessageBox.Show("No se encontró un alumno con ese id"); return; }
            else
            {
                txtNombre.Text = alumnoAbuscar.nombre;
                txtApellido.Text = alumnoAbuscar.apellido;
                txtDni.Text = alumnoAbuscar.dni;


                // a) dejar todo destildado
                for (int i = 0; i < clbCarreras.Items.Count; i++)
                    clbCarreras.SetItemChecked(i, false);

                // b) recorrer cada id que trae el alumno y marcarla
                foreach (int idSeleccionado in alumnoAbuscar.carrerasIds)   // ej. [0, 3, 5]
                {
                    for (int i = 0; i < clbCarreras.Items.Count; i++)
                    {
                        // cada item vuelve a ser CarrerasResponse porque lo guardaste así
                        var carrera = (CarrerasResponse)clbCarreras.Items[i];

                        if (carrera.id == idSeleccionado)
                        {
                            clbCarreras.SetItemChecked(i, true);
                            break;                       // pasa al siguiente id
                        }
                    }
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

                

                if (listaAlumnos == null || listaAlumnos.Count == 0)
                {
                    MessageBox.Show("La lista de alumnos se ha cargado con exito pero está vacía.");
                    return;
                }
                MessageBox.Show($"Se han cargado con exito {listaAlumnos.Count} alumnos", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex) { MessageBox.Show(ex.Message, "Error al traer alumnos"); }

            }

            

        private void MenuAdmin1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            menuAdmin.Show();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            List<long> carrerasSeleccionadas = new List<long>();

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string DNI = txtDni.Text;

            if (string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(apellido) || //Aca validamos que no esten vacias las variables del alumno que pasamos por referencia
                string.IsNullOrEmpty(DNI))
            {
                MessageBox.Show("Nombre, apellido, DNI son obligatorios.");
                return;
            }


            if (clbCarreras.CheckedItems.Count == 0)
            {
                MessageBox.Show("Debe seleccionar al menos una carrera.");
                return;                                // corta el evento porque valida si hay alguna carrera seleccionada
            }
            if (!string.IsNullOrWhiteSpace(txtidAlumno.Text))
            { MessageBox.Show("El Id no es necesario para crear un alumno, por favor borrelo."); return; }
            if (txtDni.Text.Length < 7 || txtDni.Text.Length > 8)
            {MessageBox.Show("El DNI debe tener 7 u 8 dígitos.");return;}
            if (!int.TryParse(txtDni.Text, out int dni))
            { MessageBox.Show("El Dni debe ser númerico"); return; }
           
            if(listaAlumnos.Count == 0)
            { MessageBox.Show("Debe cargar la lista de alumnos primero."); return; }
            if(listaAlumnos.Find(a => a.dni == txtDni.Text) != null)
            { MessageBox.Show("Ya existe un alumno registrado con ese Dni"); return; }
            



            //Por cada Item checked, como esa lista son los objetos carreraResponse cargados, carrera lo transformo en Carrerarepsonde item, que es cada seleccion.
            foreach (var item in clbCarreras.CheckedItems)
            {
                var carrera = (CarrerasResponse)item; //casteo o transformo
                carrerasSeleccionadas.Add(carrera.id); //Agrego el ide a la lista de carrerasSeleccionadas
            }

                long id = 0;
                AgregarAlumnoNegocio nuevo = new AgregarAlumnoNegocio();  
                string msj = nuevo.AgregarAlumno(nombre,apellido,DNI,id,carrerasSeleccionadas);

            if (msj == "OK")
            {
                try
                {
                    ListaAlumnos listaAllamar = new ListaAlumnos(); //Instancio la clase de Negocio que contiene el metodo a llamar

                    listaAlumnos = listaAllamar.TraerAlumnos();
                    Alumnos alumnoAgregado = listaAlumnos.Find(a => a.dni == txtDni.Text);

                    MessageBox.Show($"Alumno nuevo añadido con exito (id: {alumnoAgregado.id}.) \n Lista actualizada: Hay {listaAlumnos.Count} alumnos.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtidAlumno.Text = alumnoAgregado.id.ToString();
                    

                }
                catch (Exception ex) { MessageBox.Show("Alumno agregado con exito, pero ha ocurrido un error actualizando la lista de alumnos. \n (Recargue la lista nuevamente)", ex.ToString()); }
            }
            else { MessageBox.Show("Error al agregar el alumno", msj); }

        }   
        

        private void MenuAdmin1_Load(object sender, EventArgs e)
        {
            try
            {
                CargarCarreras cc = new CargarCarreras();
                Carreras = cc.cargarCarreras();

                clbCarreras.Items.Clear();
                clbCarreras.DataSource = Carreras;
                clbCarreras.DisplayMember = "nombre";// el texto visible será carrera.nombre
                clbCarreras.ValueMember = "id";

            }

            catch (Exception ex) { MessageBox.Show("Error al cargar las carreras",ex.ToString()); }
        }

            private void btnLimpiar_Click(object sender, EventArgs e)
            {
                txtDni.Clear();
                txtNombre.Clear();
                txtApellido.Clear();
                txtidAlumno.Clear();
            // Esto destilda todas las carreras
            for (int i = 0; i < clbCarreras.Items.Count; i++)
                clbCarreras.SetItemChecked(i, false);

            // (opcional) sacar también el resaltado
            clbCarreras.ClearSelected();

            }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            long IdAlumno;

            if (string.IsNullOrWhiteSpace(txtidAlumno.Text))
            { MessageBox.Show("Debe ingresar un Id a Eliminar"); txtidAlumno.BackColor = Color.LightBlue; return; }
            if (!long.TryParse(txtidAlumno.Text, out IdAlumno))
            { MessageBox.Show("El id ingresado debe ser númerico."); return; }
            if (IdAlumno < 0)
            { MessageBox.Show("El ID no puede ser negativo"); return; }
            if (listaAlumnos.Count == 0)
            { MessageBox.Show("Debe cargar la lista de docentes antes de eliminar."); return; }
            if (listaAlumnos.Find(ab => ab.id == IdAlumno) == null)
            { MessageBox.Show("El Id Ingresado no existe en la lista de alumnos. Pruebe otro."); return; }


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

            EliminarAlumnoNegocio a = new EliminarAlumnoNegocio();

            string Respuesta = a.EliminarAlumno(IdAlumno);
            if (Respuesta == "OK")
            {
                try
                {
                    ListaAlumnos listaAllamar = new ListaAlumnos(); //Instancio la clase de Negocio que contiene el metodo a llamar

                    listaAlumnos = listaAllamar.TraerAlumnos();

                    MessageBox.Show($"Alumno eliminado con exito. \n Lista actualizada: Hay {listaAlumnos.Count} alumnos.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex) { MessageBox.Show("Alumno eliminado con exito, pero ha ocurrido un error actualizando la lista de alumnos. \n (Recargue la lista nuevamente)", ex.ToString()); }
            }
            else { MessageBox.Show("Ha ocurrido un error, intente nuevamente.", Respuesta); }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            bool hayIncompletos = false;

            if (string.IsNullOrWhiteSpace(txtidAlumno.Text))
            {
                txtidAlumno.BackColor = Color.LightBlue;
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

            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                txtDni.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }

            if (clbCarreras.CheckedItems.Count == 0)
            {
                clbCarreras.BackColor = Color.LightBlue;
                hayIncompletos = true;
            }


            if (hayIncompletos)
            {
                MessageBox.Show("Debe completar todos los campos de la seccion Datos Alumno y el Id Alumno.");
                return;
            }
            
            if (!long.TryParse(txtidAlumno.Text, out long id))
            { MessageBox.Show("Debe ingresar un numero de curso válido"); return; } //Valido que sea numerico el id
            if (id < 0)
            { MessageBox.Show("El ID no puede ser negativo"); return; }
            if (!int.TryParse(txtDni.Text, out int dni))
            { MessageBox.Show("El dni debe ser númerico"); return; }
            if (txtDni.Text.Length > 8)
            { MessageBox.Show("El DNI no puede tener más de 8 caracteres."); return; }
            if (txtDni.Text.Length < 7)
            { MessageBox.Show("El DNI debe tener al menos 7 caracteres."); return; }

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string dnitexto = txtDni.Text;
            List<long> carrerasSeleccionadas = new List<long>();


            //Por cada Item checked, como esa lista son los objetos carreraResponse cargados, carrera lo transformo en Carrerarepsonde item, que es cada seleccion.
            foreach (var item in clbCarreras.CheckedItems)
            {
                var carrera = (CarrerasResponse)item; //casteo o transformo
                carrerasSeleccionadas.Add(carrera.id); //Agrego el ide a la lista de carrerasSeleccionadas
            }



            ActualizarAlumnoNegocio a = new ActualizarAlumnoNegocio();


            string Respuesta = a.ActualizarAlumno(nombre, apellido, dnitexto,carrerasSeleccionadas, id);

            if (Respuesta == "OK")
            {
                try
                {
                    ListaAlumnos listaAllamar = new ListaAlumnos(); //Instancio la clase de Negocio que contiene el metodo a llamar

                    listaAlumnos = listaAllamar.TraerAlumnos();

                    MessageBox.Show($"Alumno actualizado con exito.", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex) { MessageBox.Show("Alumno actualizado con exito, pero ha ocurrido un error actualizando la lista de alumnos. \n (Recargue la lista nuevamente)", ex.ToString()); }
            }
            else { MessageBox.Show("Ha ocurrido un error, intente nuevamente.", Respuesta); }

        }

        private void clbCarreras_Enter(object sender, EventArgs e)
        {
            clbCarreras.BackColor = Color.White;
        }
    }
}
