using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Alumnos    
    {
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string dni { get; set; }

        
        public List<int> carrerasIds { get; set; } = new List<int>(); //Si un alumno puede cursar varias carreras, List<int>

    }
}
