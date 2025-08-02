using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Menu_Admin.ABM_DocentesClases;
using Persistencia;
using Persistencia.Menu_AdminPersistencia.AMB_DocentesPersistencia;

namespace Capa_de_Negocios
{
    public class ActualizarAlumnoNegocio
    {
        public string ActualizarAlumno(string nombre, string apellido, string dni, List<long> carreras, long id)
        {
            Alumnos d = new Alumnos();
            { d.nombre = nombre; d.apellido = apellido; d.dni = dni; d.carrerasIds = carreras; d.id = id; }

            ActualizarAlumnoPersistencia add = new ActualizarAlumnoPersistencia();
            string msj = add.ActualizarAlumno(id, d);

            return msj;

        }

    }
}
