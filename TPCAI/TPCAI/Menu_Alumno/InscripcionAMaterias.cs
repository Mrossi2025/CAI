using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Capa_de_Negocios;
using Persistencia;
using Datos;

namespace TPCAI
{
    public partial class InscripcionAMaterias : Form
    {
        private int _alumnoId;

        // Estado en memoria
        private List<Materias> _materiasDisponibles = new List<Materias>();
        private List<MateriaInscriptaDTO> _estadoMateriasAlumno = new List<MateriaInscriptaDTO>();
        private List<Cursos> _cursosDeMateriaActual = new List<Cursos>();
        private readonly List<Cursos> _cursosSeleccionados = new List<Cursos>();

        public InscripcionAMaterias(int alumnoId)
        {
            InitializeComponent();
            _alumnoId = alumnoId;
        }

        private void InscripcionAMaterias_Load(object sender, EventArgs e)
        {
            try
            {
                // 1) Traemos el alumno y sus carreras
                var repoAlu = new RepositorioAlumno();
                var todos = repoAlu.ObtenerAlumnos();
                var alumno = todos.FirstOrDefault(a => a.id == _alumnoId);
                if (alumno == null)
                {
                    MessageBox.Show("No se encontró el alumno.");
                    Close();
                    return;
                }

                // 2) Traemos estado de materias del alumno (aprobadas/final/etc.)
                var reporte = new GenerarReportePersistencia();
                _estadoMateriasAlumno = reporte.ObtenerMateriasPorAlumno(_alumnoId) ?? new List<MateriaInscriptaDTO>();

                // 3) Habilitamos materias por cada carrera del alumno, validando correlativas
                var negocioMaterias = new CargarMateriasNegocio();
                _materiasDisponibles.Clear();

                foreach (var carreraIdLong in alumno.carrerasIds) // List<long>
                {
                    var materiasCarrera = negocioMaterias.CargarMaterias(carreraIdLong);
                    if (materiasCarrera == null) continue;

                    foreach (var mat in materiasCarrera)
                    {
                        if (MateriaHabilitadaPorCorrelativas(mat))
                        {
                            // Evitar duplicados (si la materia aparece en varias carreras)
                            if (_materiasDisponibles.All(m => m.id != mat.id))
                                _materiasDisponibles.Add(mat);
                        }
                    }
                }

                // 4) Bind a UI
                cmbMaterias.DisplayMember = "nombre";
                cmbMaterias.ValueMember = "id";
                cmbMaterias.DataSource = _materiasDisponibles;

                // DataGrid simple
                dgvCursos.AutoGenerateColumns = true;
                dgvCursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvCursos.MultiSelect = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando datos: " + ex.Message);
            }
        }

        private bool MateriaHabilitadaPorCorrelativas(Materias materia)
        {
            // Regla: correlativas aprobadas o con final pendiente
            if (materia.correlativas == null || materia.correlativas.Count == 0)
                return true;

            foreach (var corr in materia.correlativas)
            {
                var estado = _estadoMateriasAlumno
                    .FirstOrDefault(m => m.id == corr.id);

                var cond = estado?.condicion ?? string.Empty;
                bool ok = cond == "APROBADO" || cond == "FINAL";

                if (!ok) return false;
            }
            return true;
        }

        private void cmbMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMaterias.SelectedValue == null) return;
            if (!long.TryParse(cmbMaterias.SelectedValue.ToString(), out long materiaId)) return;

            try
            {
                // Cargar cursos de la materia seleccionada
                var negocioCursos = new CargarCursosNegocio();
                _cursosDeMateriaActual = negocioCursos.CargarCursos(materiaId) ?? new List<Cursos>();

                // Mostramos datos legibles
                var view = _cursosDeMateriaActual.Select(c => new
                {
                    c.id,
                    Profesor = c.profesorNombre,
                    Dias = string.Join(", ", c.dias ?? new List<string>()),
                    Horarios = string.Join(" | ", (c.horarios ?? new List<Horarios>())
                                .Select(h => $"{h.dia} {h.horaInicio}-{h.horaFin}"))
                }).ToList();

                dgvCursos.DataSource = view;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando cursos: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (dgvCursos.CurrentRow == null)
            {
                MessageBox.Show("Seleccioná un curso de la grilla.");
                return;
            }

            // Tomamos el id de la fila seleccionada
            if (!long.TryParse(dgvCursos.CurrentRow.Cells["id"].Value.ToString(), out long cursoId))
            {
                MessageBox.Show("No se pudo identificar el curso.");
                return;
            }

            var curso = _cursosDeMateriaActual.FirstOrDefault(c => c.id == cursoId);
            if (curso == null)
            {
                MessageBox.Show("Curso no encontrado en la lista actual.");
                return;
            }

            // Regla: no permitir 2 cursos de la misma materia
            // (Para chequear materia, comparamos si ya hay un curso cuyo ID pertenezca a la misma materia.
            // Como el DTO no trae "materiaId", simplificamos: no agregar si ya hay un curso con el mismo profesor y mismos horarios)
            bool mismaMateriaHeuristica = _cursosSeleccionados.Any(c =>
                string.Join(",", c.horarios?.Select(h => $"{h.dia}{h.horaInicio}{h.horaFin}") ?? new List<string>())
                ==
                string.Join(",", curso.horarios?.Select(h => $"{h.dia}{h.horaInicio}{h.horaFin}") ?? new List<string>())
            );

            if (mismaMateriaHeuristica)
            {
                MessageBox.Show("Ya seleccionaste un curso con el mismo bloque horario (se asume misma materia).");
                return;
            }

            // Validar superposición horaria
            if (HaySolapamiento(curso))
            {
                MessageBox.Show("El curso se superpone horariamente con otro ya seleccionado.");
                return;
            }

            _cursosSeleccionados.Add(curso);
            lstMateriasInscriptas.Items.Add(DescripcionCurso(curso));
        }

        private bool HaySolapamiento(Cursos nuevo)
        {
            if (nuevo.horarios == null || nuevo.horarios.Count == 0) return false;

            foreach (var ya in _cursosSeleccionados)
            {
                if (ya.horarios == null) continue;

                foreach (var h1 in ya.horarios)
                    foreach (var h2 in nuevo.horarios)
                    {
                        if (!string.Equals(h1.dia, h2.dia, StringComparison.OrdinalIgnoreCase))
                            continue;

                        // Parseo HH:mm
                        if (!TimeSpan.TryParse(h1.horaInicio, out var i1)) continue;
                        if (!TimeSpan.TryParse(h1.horaFin, out var f1)) continue;
                        if (!TimeSpan.TryParse(h2.horaInicio, out var i2)) continue;
                        if (!TimeSpan.TryParse(h2.horaFin, out var f2)) continue;

                        bool solapan = i1 < f2 && i2 < f1; // clásico check de solape
                        if (solapan) return true;
                    }
            }
            return false;
        }

        private string DescripcionCurso(Cursos c)
        {
            var dias = string.Join(", ", c.dias ?? new List<string>());
            var hs = string.Join(" | ", (c.horarios ?? new List<Horarios>())
                        .Select(h => $"{h.dia} {h.horaInicio}-{h.horaFin}"));
            return $"[{c.id}] {c.profesorNombre} — {dias} — {hs}";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_cursosSeleccionados.Count == 0)
            {
                MessageBox.Show("No hay cursos seleccionados.");
                return;
            }

            // Guardado local (en memoria estática)
            InscripcionLocalStore.Confirmar(_alumnoId, _cursosSeleccionados);

            MessageBox.Show("¡Inscripción realizada localmente!");
            _cursosSeleccionados.Clear();
            lstMateriasInscriptas.Items.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
