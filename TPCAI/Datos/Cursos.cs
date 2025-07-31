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
        public long id {  get; set; }
        public List<Docente> docentes { get; set; } //Preguntar si esta clase esta bien o hay que agregar cursos, porque cursos entra en loop de datos y tira una banda. (Deberia ser idDocente y no una lista de clases docente)

        public Materias materia { get; set; }

        public Horarios horarios { get; set; }


    }
}
