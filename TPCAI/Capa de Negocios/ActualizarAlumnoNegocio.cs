using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class ActualizarAlumnoNegocio
    {
        public string ActualizarAlumno(string nombre, string apellido, string dni, List<long> carreras, long id)
        {

            Alumnos d = new Alumnos();
            { d.nombre = nombre; d.apellido = apellido; d.dni = dni; d.carrerasIds = carreras; d.id = id; }


            ActualizarAlumnoPersistencia add = new ActualizarAlumnoPersistencia();
            

            return add.ActualizarAlumno(id, d);

        }

    }
}
