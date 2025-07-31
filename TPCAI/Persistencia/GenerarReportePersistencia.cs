using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Persistencia.utils;
using Datos;
using Datos.EgresadosReportes;

namespace Persistencia.Menu_AdminPersistencia.Egresados
{
    public class GenerarReportePersistencia
    {
        public List<MateriaInscriptaDTO> ObtenerMateriasPorAlumno(long alumnoId)
        {
            string endpoint = $"tpIntensivo/alumno/{alumnoId}/materias";
            HttpResponseMessage response = WebHelper.Get(endpoint);

            if (!response.IsSuccessStatusCode)
                throw new Exception($"Error al obtener materias: {(int)response.StatusCode} - {response.ReasonPhrase}");

            string json = response.Content.ReadAsStringAsync().Result;

            List<MateriaInscriptaDTO> materias = JsonConvert.DeserializeObject<List<MateriaInscriptaDTO>>(json);

            return materias;
        }

    }
}
