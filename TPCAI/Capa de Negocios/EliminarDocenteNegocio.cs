using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class EliminarDocenteNegocio
    {
       
        
            public string EliminarDocente(long id)
            {
                EliminarDocentePersistencia add = new EliminarDocentePersistencia();
                return add.EliminarDocente(id);

            }



        


    }
}
