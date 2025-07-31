using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Menu_Admin.ABM_DocentesClases;
using Persistencia.Menu_AdminPersistencia.AMB_DocentesPersistencia;

namespace Capa_de_Negocios.Menu_Admin.ABM_Docentes
{
    public class EliminarDocenteNegocio
    {
       
        
            public string EliminarDocente(long id)
            {
                EliminarDocentePersistencia add = new EliminarDocentePersistencia();
                string msj = add.EliminarDocente(id);

                return msj;

            }



        


    }
}
