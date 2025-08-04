using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Materias
    {
        public long id {  get; set; }
        public string nombre { get; set; }
        public int horasSemanales {  get; set; }
        public List<Materias> correlativas { get; set; }




    }

}
