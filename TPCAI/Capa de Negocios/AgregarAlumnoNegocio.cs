using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class AgregarAlumnoNegocio
    {
        public string AgregarAlumno(string nombre, string apellido, string dni, long id, List<long> carreras)
        {
            Alumnos alumnoNuevo = new Alumnos();

            alumnoNuevo.id = id;
            alumnoNuevo.nombre = nombre;
            alumnoNuevo.apellido = apellido;
            alumnoNuevo.dni = dni;
            alumnoNuevo.carrerasIds = carreras;


            AgregarAlumnoPersistencia respuesta = new AgregarAlumnoPersistencia();//Instanciamos a AgregarAlumnoPersistencia
            string resultado = respuesta.AgregarAlumno(alumnoNuevo);   // El resultado se almacena, puede ser "OK" o "Error …"

            return resultado;
        }
    }
}
