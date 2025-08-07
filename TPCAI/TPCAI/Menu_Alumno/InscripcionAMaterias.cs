using Datos.Menu_Admin.ABM_DocentesClases;
using Persistencia;
using Persistencia.Menu_ReporteEgresados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Datos;
using Capa_de_Negocios;
using Persistencia.Menu_AdminPersistencia.Egresados;
using Datos.EgresadosReportes;

namespace TPCAI
{
    public partial class InscripcionAMaterias : Form
    {
        private int idAlumno;
        private RepositorioAlumno repositorioAlumno;
        private CargarMateriasCarreraPersistencia materiasPersistencia;
        private Alumnos alumnoActual;
        private CargarCursosMateriaPersistencia cursosPersistencia = new CargarCursosMateriaPersistencia();
        private List<Docente> listaDocentes;

        public InscripcionAMaterias(int idAlumno)
        {
            InitializeComponent();
            this.idAlumno = idAlumno;
            repositorioAlumno = new RepositorioAlumno();
            materiasPersistencia = new CargarMateriasCarreraPersistencia();
        }

        private void InscripcionAMaterias_Load(object sender, EventArgs e)
        {
            if (ObtenerInformacionAlumno())
            {
                CargarCarrerasDelAlumno();
            }
            try
            {
                ListaDocentes loader = new ListaDocentes();
                listaDocentes = loader.ObtenerListaDocentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar docentes: " + ex.Message);
            }
        }

        private bool ObtenerInformacionAlumno()
        {
            try
            {
                var alumnos = repositorioAlumno.ObtenerAlumnos();
                alumnoActual = alumnos.Find(a => a.id == idAlumno);

                if (alumnoActual == null)
                {
                    MessageBox.Show("No se encontró información del alumno.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener información del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CargarCarrerasDelAlumno()
        {
            try
            {
                var cargarCarreras = new CargarCarreras();
                var todasLasCarreras = cargarCarreras.cargarCarreras();
                cmbCarrera1.Items.Clear();
                cmbCarrera2.Items.Clear();
                cmbCarrera3.Items.Clear();
                foreach (var carrera in todasLasCarreras)
                {
                    if (alumnoActual.carrerasIds.Contains(carrera.id))
                    {
                        cmbCarrera1.Items.Add(carrera);
                        cmbCarrera2.Items.Add(carrera);
                        cmbCarrera3.Items.Add(carrera);
                    }
                }
                cmbCarrera1.DisplayMember = "nombre";
                cmbCarrera1.ValueMember = "id";
                cmbCarrera2.DisplayMember = "nombre";
                cmbCarrera2.ValueMember = "id";
                cmbCarrera3.DisplayMember = "nombre";
                cmbCarrera3.ValueMember = "id";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las carreras: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<Materias> ObtenerMateriasDeCarrera(long idCarrera)
        {
            try
            {
                return materiasPersistencia.cargarMateriasCarrera(idCarrera);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener materias de la carrera: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Materias>();
            }
        }

        private void CargarMateriasEnComboBox(List<Materias> materias, ComboBox cmbMateria)
        {
            cmbMateria.Items.Clear();
            foreach (var materia in materias)
            {
                cmbMateria.Items.Add(materia);
            }
            cmbMateria.DisplayMember = "nombre";
            cmbMateria.ValueMember = "id";
        }

        private void CargarMateriasDeCarreraSeleccionadaYAlumno(long idCarrera, ComboBox cmbMateria)
        {
            try
            {
                var materiasCarrera = ObtenerMateriasDeCarrera(idCarrera);
                var materiasAlumno = ObtenerMateriasDelAlumno();
                var materiasDisponibles = new List<Materias>();
                foreach (var materiaCarrera in materiasCarrera)
                {
                    var materiaAlumno = materiasAlumno.FirstOrDefault(m => m.id == materiaCarrera.id);
                    if (materiaAlumno == null || materiaAlumno.condicion == "DESAPROBADO")
                    {
                        materiasDisponibles.Add(materiaCarrera);
                    }
                }
                CargarMateriasEnComboBox(materiasDisponibles, cmbMateria);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar materias de la carrera: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCarrera1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles(cmbCurso1, lblHorarios1, lblDocente1, cmbMateria1);
            var carreraSeleccionada = cmbCarrera1.SelectedItem;
            if (carreraSeleccionada == null) return;
            var prop = carreraSeleccionada.GetType().GetProperty("id");
            if (prop != null)
            {
                long idCarrera = Convert.ToInt64(prop.GetValue(carreraSeleccionada));
                CargarMateriasDeCarreraSeleccionadaYAlumno(idCarrera, cmbMateria1);
            }
        }

        private void cmbCarrera2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles(cmbCurso2, lblHorarios2, lblDocente2, cmbMateria2);
            var carreraSeleccionada = cmbCarrera2.SelectedItem;
            if (carreraSeleccionada == null) return;
            var prop = carreraSeleccionada.GetType().GetProperty("id");
            if (prop != null)
            {
                long idCarrera = Convert.ToInt64(prop.GetValue(carreraSeleccionada));
                CargarMateriasDeCarreraSeleccionadaYAlumno(idCarrera, cmbMateria2);
            }
        }

        private void cmbCarrera3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles(cmbCurso3, lblHorarios3, lblDocente3, cmbMateria3);
            var carreraSeleccionada = cmbCarrera3.SelectedItem;
            if (carreraSeleccionada == null) return;
            var prop = carreraSeleccionada.GetType().GetProperty("id");
            if (prop != null)
            {
                long idCarrera = Convert.ToInt64(prop.GetValue(carreraSeleccionada));
                CargarMateriasDeCarreraSeleccionadaYAlumno(idCarrera, cmbMateria3);
            }
        }

        private void cmbMateria1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles(cmbCurso1, lblHorarios1, lblDocente1);

            if (cmbMateria1.SelectedItem != null)
            {
                var materiaSeleccionada = (Materias)cmbMateria1.SelectedItem;
                var cursos = cursosPersistencia.cargarCursosMateria(materiaSeleccionada.id);
                CargarCursosEnComboBox(cursos, cmbCurso1);
            }
        }

        private void cmbMateria2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles(cmbCurso2, lblHorarios2, lblDocente2);

            if (cmbMateria2.SelectedItem != null)
            {
                var materiaSeleccionada = (Materias)cmbMateria2.SelectedItem;
                var cursos = cursosPersistencia.cargarCursosMateria(materiaSeleccionada.id);
                CargarCursosEnComboBox(cursos, cmbCurso2);
            }
        }

        private void cmbMateria3_SelectedIndexChanged(object sender, EventArgs e)
        {
            LimpiarControles(cmbCurso3, lblHorarios3, lblDocente3);

            if (cmbMateria3.SelectedItem != null)
            {
                var materiaSeleccionada = (Materias)cmbMateria3.SelectedItem;
                var cursos = cursosPersistencia.cargarCursosMateria(materiaSeleccionada.id);
                CargarCursosEnComboBox(cursos, cmbCurso3);
            }
        }

        private void cmbCurso1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curso = cmbCurso1.SelectedItem as Cursos;
            MostrarHorariosYDocentes(curso, lblHorarios1, lblDocente1);
        }

        private void cmbCurso2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curso = cmbCurso2.SelectedItem as Cursos;
            MostrarHorariosYDocentes(curso, lblHorarios2, lblDocente2);
        }

        private void cmbCurso3_SelectedIndexChanged(object sender, EventArgs e)
        {
            var curso = cmbCurso3.SelectedItem as Cursos;
            MostrarHorariosYDocentes(curso, lblHorarios3, lblDocente3);
        }

        private List<MateriaInscriptaDTO> ObtenerMateriasDelAlumno()
        {
            try
            {
                var persistencia = new GenerarReportePersistencia();
                return persistencia.ObtenerMateriasPorAlumno(idAlumno);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener materias del alumno: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<MateriaInscriptaDTO>();
            }
        }

        private void CargarCursosEnComboBox(List<Cursos> cursos, ComboBox cmbCurso)
        {
            cmbCurso.Items.Clear();
            foreach (var curso in cursos)
            {
                cmbCurso.Items.Add(curso);
            }
            cmbCurso.DisplayMember = "profesorNombre";
            cmbCurso.ValueMember = "id";
        }

        private void MostrarHorariosYDocentes(Cursos curso, Label lblHorarios, Label lblDocente)
        {
            string horariosText = "No hay horarios disponibles.";
            string docentesText = "No hay docentes.";

            if (curso != null)
            {
                if (curso.horarios != null && curso.horarios.Count > 0)
                {
                    horariosText = string.Join(Environment.NewLine,
                        curso.horarios.Select(h => $"{h.dia}: {h.horaInicio} - {h.horaFin}"));
                }
                if (curso.idDocentes != null && curso.idDocentes.Count > 0 && listaDocentes != null)
                {
                    var nombres = listaDocentes
                        .Where(d => curso.idDocentes.Contains(d.id))
                        .Select(d => d.DocenteCompleto);
                    docentesText = string.Join(Environment.NewLine, nombres);
                }
            }

            lblHorarios.Text = horariosText;
            lblDocente.Text = docentesText;
        }

        private void LimpiarControles(ComboBox cmbCurso, Label lblHorarios, Label lblDocente, ComboBox cmbMateria = null)
        {
            // Limpiar controles de materia si se proporciona
            if (cmbMateria != null)
            {
                cmbMateria.Items.Clear();
                cmbMateria.Text = "";
            }
            
            // Limpiar controles de curso y etiquetas siempre
            cmbCurso.Items.Clear();
            cmbCurso.Text = "";
            lblHorarios.Text = "";
            lblDocente.Text = "";
        }
    }
}
