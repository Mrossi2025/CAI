using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class ListaDocentes
    {
        public List<Docente> ObtenerListaDocentes()
        {

            List<Docente> Lista = new List<Docente>();
            ObtenerDocentesPersistencia odp = new ObtenerDocentesPersistencia();

            Lista = odp.ObtenerDocentes();

          return Lista;
        }
    }

}




    
