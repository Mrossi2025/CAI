using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Newtonsoft.Json;
using Persistencia.utils;

namespace Persistencia
{
    public class AgregarAlumnoPersistencia
    {
        public string AgregarAlumno(Alumnos nuevo)
        {
            // Serializar el objeto alumno ⇒ JSON
            string json = JsonConvert.SerializeObject(nuevo);

            // Llamada POST
            HttpResponseMessage resp = WebHelper.Post("tpIntensivo/alumno", json);

            // Éxito  (códigos 2xx)
            if (resp.IsSuccessStatusCode)
                return "OK";

            // Falla: devolvés un mensaje con el código y la razón
            return $"Error {(int)resp.StatusCode} – {resp.ReasonPhrase}";
        }


    }
}
