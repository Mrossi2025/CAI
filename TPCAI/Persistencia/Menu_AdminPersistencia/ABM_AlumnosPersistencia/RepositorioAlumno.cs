using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Persistencia.utils;
using Datos;
using Capa_de_Negocios;

namespace Persistencia
{
    public class RepositorioAlumno
    {
       
    
            public List<Alumnos> ObtenerAlumnos()
            {
                // 1) GET al endpoint
                HttpResponseMessage resp = WebHelper.Get("tpIntensivo/alumnos");

                if (!resp.IsSuccessStatusCode)
                    throw new Exception($"[{(int)resp.StatusCode}] {resp.ReasonPhrase}");

                // 2) Deserializar el array JSON → List<Alumno>
                string json = resp.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<List<Alumnos>>(json) ?? new List<Alumnos>();
        }//Esto deserializa los datos que vienen del GET y forma la lista con los datos en cache.
        


    }
}
