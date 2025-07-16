using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios
{
    public class Login
    {
        public string ValidarUsuario(string usuario, string contraseña, List<Usuarios> ListaUsuarios)

        {
            
            
            Usuarios usuarioEncontrado;
            string errores = "";

            usuarioEncontrado = ListaUsuarios.Find(u => u.NombreUsuario == usuario);
            
                if (usuarioEncontrado == null)
                {
                
                errores = "No se ha encontrado un usuario con ese dato." ;
                

                }
                else if (  usuarioEncontrado.Contraseña != contraseña)
                {
                
                errores = "La contraseña es incorrecta.";
                
                }
                else { errores = "";  }




                return errores;
        }


        public string BloquearUsuario(string usuario, List<Usuarios> lista)
        {
            Usuarios Encontrado = lista.Find(a => a.NombreUsuario == usuario);

            if (Encontrado == null) return "El usuario no existe.";


            Encontrado.Estado = false;

                return "Se ha bloqueado el usuario, por favor pida a un administrador que lo desbloquee";

        }


    }
}
