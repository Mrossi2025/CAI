using System;
using System.Linq;
using System.Windows.Forms;
using Persistencia;
using Datos;

namespace TPCAI.Menu_Alumno
{
    public partial class RankingAlumnoForm : Form
    {
        private int _idAlumno;
        private System.Collections.Generic.List<MateriaInscriptaDTO> _materias;

        public RankingAlumnoForm(int idAlumno, System.Collections.Generic.List<MateriaInscriptaDTO> materias)
        {
            
            _idAlumno = idAlumno;
            this.Load += RankingAlumnoForm_Load;
            
            CalcularYMostrarRanking();
        }

        private void RankingAlumnoForm_Load(object sender, EventArgs e)
        {
            // Método vacío para manejar el evento Load si es necesario en el futuro
        }

        private void CalcularYMostrarRanking()
        {
            var reporte = new GenerarReportePersistencia();
            var materias = reporte.ObtenerMateriasPorAlumno(_idAlumno) ?? new System.Collections.Generic.List<MateriaInscriptaDTO>();

            int totalMaterias = materias.Count;
            int aprobadas = materias.Count(m => m.condicion == "APROBADA");
            int enFinal = materias.Count(m => m.condicion == "FINAL");
            int materiasRestantes = totalMaterias - aprobadas - enFinal;

            // A: materias aprobadas o en final * 100
            int a = (aprobadas + enFinal) * 100;
            // B: materias aprobadas * 3
            int b = aprobadas * 3;
            // C: promedio general * 3
            double promedio = materias.Where(m => m.nota.HasValue).Select(m => m.nota.Value).DefaultIfEmpty(0).Average();
            int c = (int)(promedio * 3);
            // D: adicional por cantidad de materias restantes
            int d = 0;
            switch (materiasRestantes)
            {
                case 8: d = 5; break;
                case 7: d = 10; break;
                case 6: d = 15; break;
                case 5: d = 20; break;
                case 4: d = 30; break;
                case 3: d = 45; break;
                case 2: d = 60; break;
                case 1: d = 90; break;
                default: d = 0; break;
            }

            int ranking = a + b + c + d;

            MessageBox.Show(
                $"RANKING: {ranking}",
                "Ranking calculado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }
}