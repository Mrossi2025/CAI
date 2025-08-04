using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Datos
{
    public class Cursos
    {
        public long id {  get; set; }
        public string profesorNombre { get; set; } //Preguntar si esta clase esta bien o hay que agregar cursos, porque cursos entra en loop de datos y tira una banda. (Deberia ser idDocente y no una lista de clases docente)

        public List<string> dias { get; set; }

        public List<Horarios> horarios { get; set; }

        public List<long> idDocentes { get; set; }


    }
}
