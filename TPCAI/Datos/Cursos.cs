using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_Negocios;

namespace Datos.Menu_Admin.ABM_DocentesClases
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
