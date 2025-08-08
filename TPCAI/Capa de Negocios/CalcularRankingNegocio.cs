using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class CalcularRankingNegocio
    {
        public int CalcularRanking(long _idAlumno, List<MateriaInscriptaDTO> materias)
        {
            var reporte = new GenerarReportePersistencia();
            materias = reporte.ObtenerMateriasPorAlumno(_idAlumno) ?? new List<MateriaInscriptaDTO>();

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


            return ranking;
                
            
        }
    }
}
