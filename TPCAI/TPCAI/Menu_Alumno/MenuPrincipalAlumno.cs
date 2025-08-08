using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_de_Negocios;
using Datos;
using Persistencia;
using TPCAI.Menu_Alumno; // Agrega esta directiva si RankingAlumnoForm está en este namespace.

namespace TPCAI
{
    public partial class MenuPrincipalAlumno : Form
    {
        private int idAlumno;
        List<Alumnos> listaAlumnos = new List<Alumnos>();


        public MenuPrincipalAlumno(int idAlumno) //Constructor que recibe el parametro del usuario que ingresa para ya tener sus datos a mano.
        {
            InitializeComponent();
            this.idAlumno = idAlumno;
            
        }

        public MenuPrincipalAlumno()
        {
            InitializeComponent();
        }

       /* private void MenuPrincipalAlumno_FormClosed(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Sesion Cerrada");
            Login formLogin = new Login();
            formLogin.Show();
        }*/

        private void grpMenuAlumnos_Enter(object sender, EventArgs e)
        {

        }

        private void btnInscribirte_Click(object sender, EventArgs e)
        {
            InscripcionAMaterias inscripcionAMaterias = new InscripcionAMaterias(this.idAlumno);
            inscripcionAMaterias.ShowDialog();
        }

        private void CargarAlumnos(ref List<Alumnos> alumnos)
        {
            RepositorioAlumno repo = new RepositorioAlumno();

            try
            {

                alumnos = repo.ObtenerAlumnos();


            }
            catch (Exception ex) { MessageBox.Show("Error cargando los alumnos", ex.ToString()); }






        }

        private void MenuPrincipalAlumno_Load(object sender, EventArgs e)
        {
            CargarAlumnos(ref listaAlumnos);

            Alumnos a = new Alumnos();

            a = listaAlumnos.Find(b => b.id == idAlumno);

            lblBienvenida.Text = $"Bienvenido/a {a.nombre} {a.apellido}";
        }

        

        private void btnFinales_Click(object sender, EventArgs e)
        {
            var formFinales = new InscripcionAFinales(idAlumno);
            formFinales.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Obtener la lista de materias inscriptas del alumno desde la capa de datos
            List<MateriaInscriptaDTO> materiasInscritas = ObtenerMateriasInscritasPorAlumno(idAlumno);

            var rankingForm = new RankingAlumnoForm(idAlumno, materiasInscritas);
            rankingForm.ShowDialog();
        }

        private List<MateriaInscriptaDTO> ObtenerMateriasInscritasPorAlumno(int idAlumno)
        {
            // Aquí deberías llamar a la capa de datos para obtener las materias inscriptas
            // Ejemplo: RepositorioMateriaInscripta repo = new RepositorioMateriaInscripta();
            // return repo.ObtenerPorAlumno(idAlumno);

            // Simulación para evitar error de compilación
            return new List<MateriaInscriptaDTO>();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sesion Cerrada");
            Login formLogin = new Login();
            formLogin.Show();
            this.Close();
        }
    }

}
