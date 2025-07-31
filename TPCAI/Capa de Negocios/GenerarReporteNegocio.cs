using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.EgresadosReportes;
using Datos.Menu_Admin.ABM_DocentesClases;
using Persistencia;
using Persistencia.Menu_AdminPersistencia.Egresados;
using Persistencia.Menu_ReporteEgresados;

namespace Capa_de_Negocios.ReportesEgresados
{
    public class GenerarReporteNegocio

    {
        public Reporte Reportenuevo()
        {

            // Instancio para generar la lista de alumnos
            RepositorioAlumno Repo = new RepositorioAlumno();

            //instancio para traer las materias de los alumnos
            CargarMateriasCarreraPersistencia CMP = new CargarMateriasCarreraPersistencia();

            //Creo el objeto reporte que vamos a cargar con los datos al final.
            Reporte reporte = new Reporte();

            //Carga la lista alumnos
            var lista = Repo.ObtenerAlumnos();

            //Precargamos las materias necesarias
            List<Materias> Administracion = CMP.cargarMateriasCarrera(1);
            List<Materias> Actuario = CMP.cargarMateriasCarrera(2);
            List<Materias> Contador = CMP.cargarMateriasCarrera(3);
            List<Materias> Economia = CMP.cargarMateriasCarrera(4);
            List<Materias> Sistemas = CMP.cargarMateriasCarrera(5);

            //Variables que vamos a enviar como objeto con los datos de las carreras.
            int RecibidosAdmin = 0; int RecibidosActuario = 0; int RecibidosContador = 0; int RecibidosEconomia = 0; int RecibidosSistemas = 0;
            int AdminCum = 0;       int ActuarioCum = 0;       int ContadorCum = 0;       int EconomiaCum = 0;       int SistemasCum = 0;
            int AdminMagna = 0;     int ActuarioMagna = 0;     int ContadorMagna = 0;     int EconomiaMagna = 0;     int SistemasMagna = 0;
            int AdminSumma = 0;     int ActuarioSumma = 0;     int ContadorSumma = 0;     int EconomiaSumma = 0;     int SistemasSumma = 0;
            

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
                    //Id que vamos a pasaar por parametro para obtener las materias de cada alumno.
                    long idAlumno = a.id;

                    //Creamos la lista donde vamos a almacenar las materias del alumno
                    List<MateriaInscriptaDTO> m = new List<MateriaInscriptaDTO>();

                    //instanciamos la persistencia que se encarga de obtener las materias.
                    GenerarReportePersistencia g = new GenerarReportePersistencia();

                    //Cargamos la lista con las materias del alumno pasando por parametro el dni
                    m = g.ObtenerMateriasPorAlumno(idAlumno);

                    //Estas variables son a nivel de cada alumno.
                    int materiasAprobadas = 0;
                    int sumaNotas = 0;


                    //Por cada materia verificamos si esta aprobada y la contamos.
                    foreach (MateriaInscriptaDTO materia in m)
                    {


                        if (materia.condicion == "APROBADO")
                        { materiasAprobadas++; sumaNotas += materia.nota ?? 0; }


                    }

                    //Variable donde vamos a guardar la primer carrera del alumno de la lista
                    long carrera;

                    if (a.carrerasIds != null && a.carrerasIds.Count > 0)
                    {
                        carrera = a.carrerasIds[0];
                    }
                    else
                    {
                        // Alumno sin carreras asignadas → lo saltamos
                        continue;
                    }



                    if (carrera == 1 && materiasAprobadas == Administracion.Count())
                    {
                        RecibidosAdmin++;
                        if (materiasAprobadas > 0)
                        {
                            double promedio = (double)sumaNotas / materiasAprobadas;

                            if (promedio == 10)
                                AdminSumma++;
                            else if (promedio >= 9)
                                AdminMagna++;
                            else if (promedio >= 8)
                                AdminCum++;
                        }
                    }
                    else if (carrera == 2 && materiasAprobadas == Actuario.Count())
                    {
                        RecibidosActuario++;
                        if (materiasAprobadas > 0)
                        {
                            double promedio = (double)sumaNotas / materiasAprobadas;

                            if (promedio == 10)
                                ActuarioSumma++;
                            else if (promedio >= 9)
                                ActuarioMagna++;
                            else if (promedio >= 8)
                                ActuarioCum++;
                        }
                    }
                    else if (carrera == 3 && materiasAprobadas == Contador.Count())
                    {
                        RecibidosContador++;
                        if (materiasAprobadas > 0)
                        {
                            double promedio = (double)sumaNotas / materiasAprobadas;

                            if (promedio == 10)
                                ContadorSumma++;
                            else if (promedio >= 9)
                                ContadorMagna++;
                            else if (promedio >= 8)
                                ContadorCum++;
                        }
                    }
                    else if (carrera == 4 && materiasAprobadas == Economia.Count())
                    {
                        RecibidosEconomia++;
                        if (materiasAprobadas > 0)
                        {
                            double promedio = (double)sumaNotas / materiasAprobadas;

                            if (promedio == 10)
                                EconomiaSumma++;
                            else if (promedio >= 9)
                                EconomiaMagna++;
                            else if (promedio >= 8)
                                EconomiaCum++;
                        }
                    }
                    else if (carrera == 5 && materiasAprobadas == Sistemas.Count())
                    {
                        RecibidosSistemas++;
                        if (materiasAprobadas > 0)
                        {
                            double promedio = (double)sumaNotas / materiasAprobadas;

                            if (promedio == 10)
                                SistemasSumma++;
                            else if (promedio >= 9)
                                SistemasMagna++;
                            else if (promedio >= 8)
                                SistemasCum++;
                        }
                    }

                }

                //El reporte creado al inicio, lo cargamos con los datos luego de pasar por todos los alumnos.
                {   reporte.RecibidosAdmin = RecibidosAdmin;
                    reporte.RecibidosActuario = RecibidosActuario;
                    reporte.RecibidosContador = RecibidosContador;
                    reporte.RecibidosEconomia = RecibidosEconomia;
                    reporte.RecibidosSistemas = RecibidosSistemas;

                    reporte.ActuarioCum = ActuarioCum;
                    reporte.ActuarioMagna = ActuarioMagna;
                    reporte.ActuarioSumma = ActuarioSumma;

                    reporte.ContadorCum = ContadorCum;
                    reporte.ContadorMagna = ContadorMagna;
                    reporte.ContadorSumma = ContadorSumma;

                    reporte.EconomiaCum = EconomiaCum;
                    reporte.EconomiaMagna = EconomiaMagna;
                    reporte.EconomiaSumma = EconomiaSumma;

                    reporte.SistemasCum = SistemasCum;
                    reporte.SistemasMagna = SistemasMagna;
                    reporte.SistemasSumma = SistemasSumma;

                }




                return reporte;





            }


            return reporte;





        }







    }
}
