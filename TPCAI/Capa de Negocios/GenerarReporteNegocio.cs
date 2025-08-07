using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class GenerarReporteNegocio

    {
        public List<AlumnosRecibidos> Reportenuevo()
        {

            // Instancio para generar la lista de alumnos
            RepositorioAlumno Repo = new RepositorioAlumno();

            //instancio para traer las materias de los alumnos
            CargarMateriasCarreraPersistencia CMP = new CargarMateriasCarreraPersistencia();

            //Materia donde almacenamos los recibidos
            List<AlumnosRecibidos> recibidos = new List<AlumnosRecibidos>();

            //Carga la lista alumnos
            var lista = Repo.ObtenerAlumnos();

            //Precargamos las materias necesarias
            List<Materias> Administracion = CMP.cargarMateriasCarrera(1);
            List<Materias> Actuario = CMP.cargarMateriasCarrera(2);
            List<Materias> Contador = CMP.cargarMateriasCarrera(3);
            List<Materias> Economia = CMP.cargarMateriasCarrera(4);
            List<Materias> Sistemas = CMP.cargarMateriasCarrera(5);

            //Creamos las listas long que solo van a tener los id
            List<long>AdminIdMaterias = new List<long>();
            List<long> ActuarioIdMaterias = new List<long>();
            List<long> ContadorIdMaterias = new List<long>();
            List<long> EconomiaIdMaterias = new List<long>();
            List<long> SistemasIdMaterias = new List<long>();



            foreach (Materias m in Administracion)
            {
                AdminIdMaterias.Add(m.id);
            }
            foreach (Materias m in Actuario)
            {
                ActuarioIdMaterias.Add(m.id);
            }
            foreach (Materias m in Contador)
            {
                ContadorIdMaterias.Add(m.id);
            }
            foreach (Materias m in Economia)
            {
                EconomiaIdMaterias.Add(m.id);
            }
            foreach (Materias m in Sistemas)
            {
                SistemasIdMaterias.Add(m.id);
            }



            //Listas donde van a estar almaccenados los alumnos que estudian cada carrera
            List<Alumnos> EstudiantesAdministracion = new List<Alumnos>();
            List<Alumnos> EstudiantesActuario = new List<Alumnos>();
            List<Alumnos> EstudiantesContador = new List<Alumnos>();
            List<Alumnos> EstudiantesEconomia = new List<Alumnos>();
            List<Alumnos> EstudiantesSistemas = new List<Alumnos>();
            List<Alumnos> EstudiantesSinCarrera = new List<Alumnos>();





            //Validacion si la lista de alumnos es null o vacia
            if (lista == null || !lista.Any())
            {
                // Acción alternativa: mensaje, excepción, lista por defecto, etc.
                lista = new List<Alumnos>();

            }
            else
            {
                foreach (Alumnos a in lista)
                {

                    if (a.carrerasIds.Contains(1))
                    { EstudiantesAdministracion.Add(a); }
                    if (a.carrerasIds.Contains(2))
                    { EstudiantesActuario.Add(a); }
                    if (a.carrerasIds.Contains(3))
                    { EstudiantesContador.Add(a); }
                    if (a.carrerasIds.Contains(4))
                    { EstudiantesEconomia.Add(a); }
                    if (a.carrerasIds.Contains(5))
                    { EstudiantesSistemas.Add(a); }
                    if (!a.carrerasIds.Any(id => id >= 1 && id <= 5))
                    {EstudiantesSinCarrera.Add(a);}



                }

                //Creamos la lista donde vamos a almacenar las materias del alumno
                List<MateriaInscriptaDTO> MateriaPorAlumno = new List<MateriaInscriptaDTO>();

                //instanciamos la persistencia que se encarga de obtener las materias.
                GenerarReportePersistencia g = new GenerarReportePersistencia();

                foreach(Alumnos a in EstudiantesAdministracion)
                {

                    int materiasAprobadas = 0;
                    int? notas = 0;

                    
                    
                        //Cargamos la lista con las materias del alumno pasando por parametro el dni
                        MateriaPorAlumno = g.ObtenerMateriasPorAlumno(a.id);
                    
                    

                    foreach(MateriaInscriptaDTO m in MateriaPorAlumno)
                    {
                        if(AdminIdMaterias.Contains(m.id) && m.condicion == "APROBADO")
                            { materiasAprobadas++; notas = notas + m.nota ?? 0; } //el ?? 0 es por si es null para que no se frene la logica y lo reemplace por 0


                    }

                    double promedio = (double)notas /Administracion.Count();

                    if (materiasAprobadas >= Administracion.Count())
                    {
                        AlumnosRecibidos alumno = new AlumnosRecibidos();
                        {
                            alumno.id = a.id;
                            alumno.nombre = a.nombre;
                            alumno.apellido = a.apellido;
                            alumno.carrera = "Administración";

                            if (materiasAprobadas >= Administracion.Count() && promedio == 10)
                            { alumno.titulo = "Summa Cum Laude"; }
                            else if (materiasAprobadas >= Administracion.Count() && promedio >= 9)
                            { alumno.titulo = "Magna Cum Laude"; }
                            else if (materiasAprobadas >= Administracion.Count() && promedio >= 8)
                            { alumno.titulo = "Cum Laude"; }
                            else if (materiasAprobadas >= Administracion.Count() && promedio < 8)
                            { alumno.titulo = "Sin título honorífico"; }

                        }

                        recibidos.Add(alumno);
                    }

                }

                foreach (Alumnos a in EstudiantesActuario)
                {

                    int materiasAprobadas = 0;
                    int? notas = 0;

                    
                    
                        //Cargamos la lista con las materias del alumno pasando por parametro el dni
                        MateriaPorAlumno = g.ObtenerMateriasPorAlumno(a.id);
                    
                    

                    foreach (MateriaInscriptaDTO m in MateriaPorAlumno)
                    {
                        if (ActuarioIdMaterias.Contains(m.id) && m.condicion == "APROBADO")
                        { materiasAprobadas++; notas = notas + m.nota ?? 0; } //el ?? 0 es por si es null para que no se frene la logica y lo reemplace por 0


                    }

                    double promedio = (double)notas / Actuario.Count();

                    if (materiasAprobadas >= Actuario.Count())
                    {
                        AlumnosRecibidos alumno = new AlumnosRecibidos();
                        {
                            alumno.id = a.id;
                            alumno.nombre = a.nombre;
                            alumno.apellido = a.apellido;
                            alumno.carrera = "Actuario";

                            if (materiasAprobadas >= Actuario.Count() && promedio == 10)
                            { alumno.titulo = "Summa Cum Laude"; }
                            else if (materiasAprobadas >= Actuario.Count() && promedio >= 9)
                            { alumno.titulo = "Magna Cum Laude"; }
                            else if (materiasAprobadas >= Actuario.Count() && promedio >= 8)
                            { alumno.titulo = "Cum Laude"; }
                            else if (materiasAprobadas >= Actuario.Count() && promedio < 8)
                            { alumno.titulo = "Sin título honorífico"; }

                        }

                        recibidos.Add(alumno);
                    }


                }

                foreach (Alumnos a in EstudiantesContador)
                {

                    int materiasAprobadas = 0;
                    int? notas = 0;

                    
                    
                        //Cargamos la lista con las materias del alumno pasando por parametro el dni
                        MateriaPorAlumno = g.ObtenerMateriasPorAlumno(a.id);
                    
                    

                    foreach (MateriaInscriptaDTO m in MateriaPorAlumno)
                    {
                        if (ContadorIdMaterias.Contains(m.id) && m.condicion == "APROBADO")
                        { materiasAprobadas++; notas = notas + m.nota ?? 0; } //el ?? 0 es por si es null para que no se frene la logica y lo reemplace por 0


                    }

                    double promedio = (double)notas / Contador.Count();

                    if (materiasAprobadas >= Contador.Count())
                    {
                        AlumnosRecibidos alumno = new AlumnosRecibidos();
                        {
                            alumno.id = a.id;
                            alumno.nombre = a.nombre;
                            alumno.apellido = a.apellido;
                            alumno.carrera = "Contador";

                            if (materiasAprobadas >= Contador.Count() && promedio == 10)
                            { alumno.titulo = "Summa Cum Laude"; }
                            else if (materiasAprobadas >= Contador.Count() && promedio >= 9)
                            { alumno.titulo = "Magna Cum Laude"; }
                            else if (materiasAprobadas >= Contador.Count() && promedio >= 8)
                            { alumno.titulo = "Cum Laude"; }
                            else if (materiasAprobadas >= Contador.Count() && promedio < 8)
                            { alumno.titulo = "Sin título honorífico"; }

                        }

                        recibidos.Add(alumno);
                    }


                }

                foreach (Alumnos a in EstudiantesEconomia)
                {

                    int materiasAprobadas = 0;
                    int? notas = 0;

                    
                    
                        //Cargamos la lista con las materias del alumno pasando por parametro el dni
                        MateriaPorAlumno = g.ObtenerMateriasPorAlumno(a.id);
                    
                    

                    foreach (MateriaInscriptaDTO m in MateriaPorAlumno)
                    {
                        if (EconomiaIdMaterias.Contains(m.id) && m.condicion == "APROBADO")
                        { materiasAprobadas++; notas = notas + m.nota ?? 0; } //el ?? 0 es por si es null para que no se frene la logica y lo reemplace por 0
                    }

                    double promedio = (double)notas / Economia.Count();

                    if (materiasAprobadas >= Economia.Count())
                    {
                        AlumnosRecibidos alumno = new AlumnosRecibidos();
                        {
                            alumno.id = a.id;
                            alumno.nombre = a.nombre;
                            alumno.apellido = a.apellido;
                            alumno.carrera = "Economía";

                            if (materiasAprobadas >= Economia.Count() && promedio == 10)
                            { alumno.titulo = "Summa Cum Laude"; }
                            else if (materiasAprobadas >= Economia.Count() && promedio >= 9)
                            { alumno.titulo = "Magna Cum Laude"; }
                            else if (materiasAprobadas >= Economia.Count() && promedio >= 8)
                            { alumno.titulo = "Cum Laude"; }
                            else if (materiasAprobadas >= Economia.Count() && promedio < 8)
                            { alumno.titulo = "Sin título honorífico"; }

                        }

                        recibidos.Add(alumno);
                    }

                }

                foreach (Alumnos a in EstudiantesSistemas)
                {

                    int materiasAprobadas = 0;
                    int? notas = 0;

                    
                        //Cargamos la lista con las materias del alumno pasando por parametro el dni
                        MateriaPorAlumno = g.ObtenerMateriasPorAlumno(a.id);
                    
                    

                    foreach (MateriaInscriptaDTO m in MateriaPorAlumno)
                    {
                        if (SistemasIdMaterias.Contains(m.id) && m.condicion == "APROBADO")
                        { materiasAprobadas++; notas = notas + m.nota ?? 0; } //el ?? 0 es por si es null para que no se frene la logica y lo reemplace por 0


                    }

                    double promedio = (double)notas / Sistemas.Count();

                    if (materiasAprobadas >= Sistemas.Count())
                    {
                        AlumnosRecibidos alumno = new AlumnosRecibidos();
                        {
                            alumno.id = a.id;
                            alumno.nombre = a.nombre;
                            alumno.apellido = a.apellido;
                            alumno.carrera = "Sistemas";

                            if (materiasAprobadas >= Sistemas.Count() && promedio == 10)
                            { alumno.titulo = "Summa Cum Laude"; }
                            else if (materiasAprobadas >= Sistemas.Count() && promedio >= 9)
                            { alumno.titulo = "Magna Cum Laude"; }
                            else if (materiasAprobadas >= Sistemas.Count() && promedio >= 8)
                            { alumno.titulo = "Cum Laude"; }
                            else if (materiasAprobadas >= Sistemas.Count() && promedio < 8)
                            { alumno.titulo = "Sin título honorífico"; }

                        }

                        recibidos.Add(alumno);
                    }

                }


                return recibidos;





            }


            return recibidos;





        }







    }
}
