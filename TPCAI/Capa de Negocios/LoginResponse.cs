using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Datos;
using System.Runtime.CompilerServices;

namespace Capa_de_Negocios
{
    public class LoginResponse
    {
        public Datos.LoginResponse login(string username, string password)
        {

            try
            {

                LoginPersistencia loginPersistencia = new LoginPersistencia();
                Datos.LoginResponse Respuesta = loginPersistencia.login(username, password);


                return Respuesta;
            }
            //Si pongo entre comillas adelante me reemplaza el mensaje
            //catch (Exception ex) { throw new Exception("Credenciales inválidas", ex);}
            catch (Exception ex) { throw; }
        }


        

        



    }
}
