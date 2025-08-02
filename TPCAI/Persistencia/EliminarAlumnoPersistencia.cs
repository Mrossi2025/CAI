using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Persistencia.utils;

namespace Persistencia
{
    public class EliminarAlumnoPersistencia
    {
        public string EliminarAlumno(long id)
        {
            // Armar la URL con el ID
            string url = $"tpIntensivo/alumno/{(long)id}";

            // Enviar PUT
            HttpResponseMessage resp = WebHelper.Delete(url);

            // Manejo de error o éxito
            if (!resp.IsSuccessStatusCode)
            {
                string err = resp.Content.ReadAsStringAsync().Result;
                return err;
            }
            else
            {
                return "OK";
            }
        }
    }
}
