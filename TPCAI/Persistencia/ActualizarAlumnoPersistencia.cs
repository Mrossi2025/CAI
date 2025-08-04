using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Newtonsoft.Json;
using Persistencia.utils;

namespace Persistencia
{
    public class ActualizarAlumnoPersistencia
    {
        public string ActualizarAlumno(long id, Alumnos alumno)
        {
            // Serializar el objeto request a JSON
            string json = JsonConvert.SerializeObject(alumno);

            // Armar la URL con el ID
            string url = $"tpIntensivo/docentes/{(long)id}";

            // Enviar PUT
            HttpResponseMessage resp = WebHelper.Put(url, json);

            // Manejo de error o éxito
            if (!resp.IsSuccessStatusCode)

            { return $"[{(int)resp.StatusCode}] {resp.ReasonPhrase}"; }
            else
            {
                return "OK";
            }
        }
    }


    
}
