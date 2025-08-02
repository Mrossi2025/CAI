using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Persistencia.Menu_AdminPersistencia.AMB_DocentesPersistencia;

namespace Capa_de_Negocios
{
    public class EliminarAlumnoNegocio
    {
        public string EliminarAlumno(long id)
        {
            EliminarAlumnoPersistencia add = new EliminarAlumnoPersistencia();
            string msj = add.EliminarAlumno(id);

            return msj;

        }
    }
}
