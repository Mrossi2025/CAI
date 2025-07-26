using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Newtonsoft.Json;
using Persistencia.utils;

namespace Persistencia
{
    public class DesbloquearUsuarioPersistencia
    {
        public string DesbloquearUsuario(DesbloquearUsuarioRequest idUsuario)
        {
            // 1) Crear el request
            
            string jsonBody = JsonConvert.SerializeObject(idUsuario);

            // 2) Llamar al endpoint
            HttpResponseMessage resp = WebHelper.Post("tpIntensivo/desbloquear", jsonBody);

            // 3) Interpretar la respuesta
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
