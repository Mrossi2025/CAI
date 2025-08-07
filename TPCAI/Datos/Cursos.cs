using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class Cursos
    {
        public long id { get; set; }
        public string profesorNombre { get; set; }
        public List<string> dias { get; set; }
        public List<Horarios> horarios { get; set; }
        public List<long> idDocentes { get; set; }

    }
}
