using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Persistencia.utils;
using Datos;
using Capa_de_Negocios;
using System.Net.Http;

namespace Persistencia
{
    public class ObtenerDocentesPersistencia
    {


        public List<Docente> ObtenerDocentes()
        {
            HttpResponseMessage resp = WebHelper.Get("tpIntensivo/docentes");

            if (!resp.IsSuccessStatusCode)
                throw new Exception($"Error {(int)resp.StatusCode} – {resp.ReasonPhrase}");

            // 2) Cuerpo en string
            string json = resp.Content.ReadAsStringAsync().Result;

            // 3) Deserialización directa
            return JsonConvert.DeserializeObject<List<Docente>>(json) ?? new List<Docente>();

            

        }
    }
}
