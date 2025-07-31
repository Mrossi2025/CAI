using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using System.Net.Http;
using Newtonsoft.Json;
using Persistencia.utils;
using System.IO;

namespace Persistencia
{
    public class LoginPersistencia
    {
        public LoginResponse login(string username, string password)
        {
            LoginRequest datosAenviar = new LoginRequest(); //Instancio el objeto a transformar en Json

            datosAenviar.user = username; //Agrego los datos que le paso por parametros y los transformo en un objeto
            datosAenviar.password = password;

            var jsonData = JsonConvert.SerializeObject(datosAenviar); //Convierte el objeto en Json (Serializo)

            HttpResponseMessage response = WebHelper.Post("tpIntensivo/login", jsonData); // Aca instanciamos la respuesta que vamos a recibir. Entre corchetes va el nombre del webservice "tpIntensivo/login" y despues de la coma va el dato que le enviamos.

            LoginResponse Respuesta = null; //aca instanciamos la respuesta que vamos a recibir y la dejamos en Null.

            if(response.IsSuccessStatusCode) //Si la consulta se realizo correctamente arroja un valor codigo de 200-299 sino false
            {
                var reader = new StreamReader(response.Content.ReadAsStreamAsync().Result); //Aca creamos una variable que va a recibir el objeto respuesta, en este caso un usuario y contraseña en un objeto en JSON.
                Respuesta = JsonConvert.DeserializeObject<LoginResponse>(reader.ReadToEnd()); //Aca deserializamos la respuesta y la transformamos en un objeto que habiamos instanciado antes

            }

            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)   // 401
                {
                    // El backend devuelve algo así:
                    // { "code": "INVALID_CREDENTIALS", "message": "Credenciales inválidas" }
                    // o { "code": "USER_BLOCKED", "message": "Usuario bloqueado" }
                    string body = response.Content.ReadAsStringAsync().Result;

                    // Deserializamos sólo para leer el mensaje
                    dynamic err = JsonConvert.DeserializeObject(body);
                    string msg = err.message ?? "Acceso no autorizado";

                    throw new Exception(msg);     // ← “Credenciales inválidas”  ó  “Usuario bloqueado”
                }

                // Otros códigos (400, 500, etc.) mantienen el mensaje genérico
                throw new Exception($"Error: {(int)response.StatusCode} - {response.ReasonPhrase}");
            }

            return Respuesta;
        }


    }
}
