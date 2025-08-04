using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Menu_Admin.ABM_DocentesClases;
using Persistencia.Menu_AdminPersistencia.AMB_DocentesPersistencia;

namespace Capa_de_Negocios.Menu_Admin.ABM_Docentes
{
    public class ActualizarDocenteNegocio
    {
        public string ActualizarDocente(string nombre, string apellido, string cuit, string dni, string tipo, List<long> curso, long id)
        {
            AgregarDocenteRequest d = new AgregarDocenteRequest();
            { d.nombre = nombre; d.apellido = apellido; d.cuit = cuit; d.dni = dni; d.tipo = tipo; d.cursos = curso; }

            ActualizarDocentePersistencia add = new ActualizarDocentePersistencia();
            

            return add.ActualizarDocente(id, d);

        }



    }
}
