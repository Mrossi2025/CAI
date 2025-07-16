using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_de_Negocios
{
    public class Usuarios
    {

        public enum TipoUsuario { Administrador, Alumno, Personal }

        //Credenciales
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }

        //datos comunes

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }
        public int Registro { get; set; }

        //Rol y Estado
        public TipoUsuario Tipo { get; set; }
        public bool Estado {  get; set; }





    } 
}
