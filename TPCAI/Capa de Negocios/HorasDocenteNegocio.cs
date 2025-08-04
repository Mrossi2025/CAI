using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistencia;
using Datos;

namespace Capa_de_Negocios
{
    public class HorasDocenteNegocio
    {
        List<Materias> m = new List<Materias>();
        CargarMateriasCarreraPersistencia CMP = new CargarMateriasCarreraPersistencia();

        public double HorasDocente(long id)
        {

            
        
            //Precargamos las materias necesarias
            List<Materias> Administracion = CMP.cargarMateriasCarrera(1);
            List<Materias> Actuario = CMP.cargarMateriasCarrera(2);
            List<Materias> Contador = CMP.cargarMateriasCarrera(3);
            List<Materias> Economia = CMP.cargarMateriasCarrera(4);
            List<Materias> Sistemas = CMP.cargarMateriasCarrera(5);

            List<Materias> MateriasUnicas = new List<Materias>();
            HashSet<long> idsAgregados = new HashSet<long>(); // para evitar repetidos, es una lista especial, distinta para no hacer find

            //unimos las materias
            var todasLasMaterias = Administracion
            .Concat(Actuario)
            .Concat(Contador)
            .Concat(Economia)
            .Concat(Sistemas);

            foreach (Materias m in todasLasMaterias)
            {
                if (idsAgregados.Add(m.id)) // Add devuelve false si ya existe
                {
                    MateriasUnicas.Add(m);
                }
            }

            List<Cursos> cursosTotales = new List<Cursos>();
            List<Cursos> cursos = new List<Cursos>();
            CargarCursosPersistencia ccp = new CargarCursosPersistencia();
            double horasMensualesTotales = 0;

            //Agregamos cada curso de cada materia
            foreach (long idMateria in idsAgregados)
            {
                cursosTotales.AddRange(ccp.CargarCursos(idMateria));
            }


            

            foreach (Cursos c in cursosTotales)
            {


                if (c.idDocentes.Contains(id))
                {
                    double horasSemanalesCurso = 0;


                    // Recorremos todos los horarios del curso
                    foreach (Horarios horario in c.horarios)
                    {
                        // Asumiendo formato HH:mm
                        TimeSpan horaInicio = TimeSpan.Parse(horario.horaInicio);
                        TimeSpan horaFin = TimeSpan.Parse(horario.horaFin);

                        double duracionHoras = (horaFin - horaInicio).TotalHours;
                        horasSemanalesCurso += duracionHoras; // sumamos la duración de cada día
                    }


                    horasMensualesTotales += horasSemanalesCurso * 4;


                }




            }

            return horasMensualesTotales;




        }






    }


        


    
}
