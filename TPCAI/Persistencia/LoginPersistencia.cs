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
                Console.WriteLine(($"Error: {response.StatusCode} - {response.ReasonPhrase}"));
                throw new Exception("Credenciales invalidas");
            }

            return Respuesta;
        }


    }
}
