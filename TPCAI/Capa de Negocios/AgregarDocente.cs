using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;


namespace Capa_de_Negocios
{
    public class AgregarDocente
    {

        public string CargarDocente(string nombre, string apellido, string cuit, string dni, string tipo, List<long> curso)
        {
            AgregarDocenteRequest d = new AgregarDocenteRequest();
            { d.nombre = nombre; d.apellido = apellido; d.cuit = cuit; d.dni = dni; d.tipo = tipo; d.cursos = curso; }

            AgregarDocentePersistencia add = new AgregarDocentePersistencia();
            

            return add.AgregarDocente(d);

        }




    }
}
