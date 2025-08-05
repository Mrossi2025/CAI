using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class CargarMateriasNegocio
    {
        public List<Materias> CargarMaterias(long id)
        {
            CargarMateriasCarreraPersistencia cmcp = new CargarMateriasCarreraPersistencia();

            return cmcp.cargarMateriasCarrera(id);
        }

    }
}
