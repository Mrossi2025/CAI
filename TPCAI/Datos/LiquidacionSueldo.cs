using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class LiquidacionSueldo
    {
        public long IdDocente { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Tipo { get; set; }
        public int Antiguedad { get; set; }
        public int Horas { get; set; }
        public decimal Sueldo { get; set; }
    }
}

