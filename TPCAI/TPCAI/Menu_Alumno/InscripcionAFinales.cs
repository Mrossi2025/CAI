using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Persistencia;
using Datos;
using Capa_de_Negocios;

namespace TPCAI
{
    public partial class InscripcionAFinales : Form
    {
        private int _alumnoId;
        private List<MateriaInscriptaDTO> _materiasPendientesFinal = new List<MateriaInscriptaDTO>();
        private readonly List<MateriaInscriptaDTO> _finalesSeleccionados = new List<MateriaInscriptaDTO>();

        public InscripcionAFinales(int alumnoId)
        {
            InitializeComponent();
            _alumnoId = alumnoId;
        }

        private void InscripcionAFinales_Load(object sender, EventArgs e)
        {
            var reporte = new GenerarReportePersistencia();
            var estado = reporte.ObtenerMateriasPorAlumno(_alumnoId) ?? new List<MateriaInscriptaDTO>();

            // Solo materias con condición "FINAL" (pendiente de rendir)
            _materiasPendientesFinal = estado.Where(m => m.condicion == "FINAL").ToList();

            cmbFinales.DisplayMember = "nombre";
            cmbFinales.ValueMember = "id";
            cmbFinales.DataSource = _materiasPendientesFinal;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (cmbFinales.SelectedValue == null) return;
            if (!long.TryParse(cmbFinales.SelectedValue.ToString(), out long materiaId)) return;

            var materia = _materiasPendientesFinal.FirstOrDefault(m => m.id == materiaId);
            if (materia == null) return;

            if (_finalesSeleccionados.Any(m => m.id == materiaId))
            {
                MessageBox.Show("Ya seleccionaste este final.");
                return;
            }

            _finalesSeleccionados.Add(materia);
            lstFinalesInscriptos.Items.Add(materia.nombre);
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (_finalesSeleccionados.Count == 0)
            {
                MessageBox.Show("No hay finales seleccionados.");
                return;
            }

            InscripcionLocalStore.ConfirmarFinales(_alumnoId, _finalesSeleccionados);
            MessageBox.Show("¡Inscripción a finales realizada localmente!");
            _finalesSeleccionados.Clear();
            lstFinalesInscriptos.Items.Clear();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}