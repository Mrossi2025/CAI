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
    public class EliminarDocentePersistencia
    {
        public string EliminarDocente(long id)
        {
            // Armar la URL con el ID
            string url = $"tpIntensivo/docentes/{id}";

            // Enviar PUT
            HttpResponseMessage resp = WebHelper.Delete(url);

            // Manejo de error o éxito
            if (resp.IsSuccessStatusCode)          // 200–299
            {
                return "OK";
            }
            else                                   // cualquier 4xx / 5xx
            {
                return $"Error {(int)resp.StatusCode} – {resp.ReasonPhrase}";
            }
        }


    }
}
