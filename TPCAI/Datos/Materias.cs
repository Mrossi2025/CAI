using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Menu_Admin.ABM_DocentesClases
{
    public class Materias
    {
        public long id {  get; set; }
        public string nombre { get; set; }
        public int horasSemanales {  get; set; }
        public Materias correlativas { get; set; }




    }

}
