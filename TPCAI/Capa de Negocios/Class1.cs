using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios
{
    public class Login
    {
        public string ValidarUsuario(string usuario, string contraseña,out int ContadorDeErrores)

        {
            
            List<Usuarios> Listadeusuarios = new List<Usuarios>(); //Aca iria la lista de usuarios (Clase). 
            string usuarioEncontrado;
            string errores = "";

            usuarioEncontrado = Usuarios.Find(u => u.usuario == usuario);
            
                if (usuarioEncontrado == null)
                {
                ContadorDeErrores++;
                errores = "No se ha encontrado un usuario con ese dato. \n Quedan " + (5 - ContadorDeErrores) + " intentos restantes." ;
                

                }
                else if (  usuarioEncontrado.contraseña != contraseña)
                {
                ContadorDeErrores++;
                errores = "La contraseña es incorrecta. \n Quedan" + (5 - ContadorDeErrores) + " intentos restantes.";
                
                }
                else { errores = "";  }




                return errores;
        }





    }
}
