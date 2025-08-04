using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Menu_Admin.ABM_DocentesClases;
using Persistencia;

namespace Capa_de_Negocios
{
    public class CargarCursosNegocio
    {
        public List<Cursos> CargarCursos(long idMateria)
        { 
            CargarCursosPersistencia ccp = new CargarCursosPersistencia();

            return ccp.CargarCursos(idMateria);

        }


    }
}
