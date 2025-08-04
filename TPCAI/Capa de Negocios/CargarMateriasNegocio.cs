using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos.Menu_Admin.ABM_DocentesClases;
using Persistencia.Menu_ReporteEgresados;

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
