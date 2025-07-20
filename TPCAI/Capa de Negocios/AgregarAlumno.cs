using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class AgregarAlumno
    {
        public string AgregarAlumnoNegocio(Alumnos alumnoNuevo)
        {

           

             
            AgregarAlumnoPersistencia respuesta = new AgregarAlumnoPersistencia();//Instanciamos a AgregarAlumnoPersistencia
            string resultado = respuesta.AgregarAlumno(alumnoNuevo);   // El resultado se almacena, puede ser "OK" o "Error …"

            if (resultado == "OK") //Validamos el resultado
                return "Alumno agregado exitosamente";

            // O podriamos lanzar una excepcion: throw new Exception(resultado);

            return $"Error al agregar alumno: {resultado}"; 
        }



    }
}
