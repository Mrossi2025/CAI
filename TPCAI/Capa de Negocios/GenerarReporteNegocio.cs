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


            //Variables que vamos a enviar como objeto con los datos de las carreras.
            int RecibidosAdmin = 0; int RecibidosActuario = 0; int RecibidosContador = 0; int RecibidosEconomia = 0; int RecibidosSistemas = 0;
            int AdminCum = 0;       int ActuarioCum = 0;       int ContadorCum = 0;       int EconomiaCum = 0;       int SistemasCum = 0;
            int AdminMagna = 0;     int ActuarioMagna = 0;     int ContadorMagna = 0;     int EconomiaMagna = 0;     int SistemasMagna = 0;
            int AdminSumma = 0;     int ActuarioSumma = 0;     int ContadorSumma = 0;     int EconomiaSumma = 0;     int SistemasSumma = 0;
            int AdminSinTitulo = 0; int ActuarioSinTitulo = 0; int ContadorSinTitulo = 0; int EconomiaSinTitulo = 0; int SistemasSinTitulo = 0;

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
                    { RecibidosAdmin++; }
                    if (materiasAprobadas >= Administracion.Count() && promedio == 10)
                    { AdminSumma++; }
                    else if (materiasAprobadas >= Administracion.Count() && promedio >= 9)
                    { AdminMagna++;}
                    else if (materiasAprobadas >= Administracion.Count() && promedio >= 8)
                    { AdminCum++; }
                    else if (materiasAprobadas >= Administracion.Count() && promedio < 8)
                    { AdminSinTitulo++; }

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
                    { RecibidosActuario++; }
                    if (materiasAprobadas >= Actuario.Count() && promedio == 10)
                    { ActuarioSumma++; }
                    else if (materiasAprobadas >= Actuario.Count() && promedio >= 9)
                    { ActuarioMagna++; }
                    else if (materiasAprobadas >= Actuario.Count() && promedio >= 8)
                    { ActuarioCum++; }
                    else if (materiasAprobadas >= Actuario.Count() && promedio < 8)
                    { ActuarioSinTitulo++; }
                    

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
                    { RecibidosContador++; }
                    if (materiasAprobadas >= Contador.Count() && promedio == 10)
                    { ContadorSumma++; }
                    else if (materiasAprobadas >= Contador.Count() && promedio >= 9)
                    { ContadorMagna++; }
                    else if (materiasAprobadas >= Contador.Count() && promedio >= 8)
                    { ContadorCum++; }
                    else if (materiasAprobadas >= Contador.Count() && promedio < 8)
                    { ContadorSinTitulo++; }
                    

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
                    { RecibidosEconomia++; }
                    if (materiasAprobadas >= Economia.Count() && promedio == 10)
                    { EconomiaSumma++; }
                    else if (materiasAprobadas >= Economia.Count() && promedio >= 9)
                    { EconomiaMagna++; }
                    else if (materiasAprobadas >= Economia.Count() && promedio >= 8)
                    { EconomiaCum++; }
                    else if (materiasAprobadas >= Economia.Count() && promedio < 8)
                    { EconomiaSinTitulo++; }

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
                    { RecibidosSistemas++; }
                    if (materiasAprobadas >= Sistemas.Count() && promedio == 10)
                    { SistemasSumma++; }
                    else if (materiasAprobadas >= Sistemas.Count() && promedio >= 9)
                    { SistemasMagna++; }
                    else if (materiasAprobadas >= Sistemas.Count() && promedio >= 8)
                    { SistemasCum++; }
                    else if (materiasAprobadas >= Sistemas.Count() && promedio < 8)
                    { SistemasSinTitulo++; }

                }


                //El reporte creado al inicio, lo cargamos con los datos luego de pasar por todos los alumnos.
                {   reporte.RecibidosAdmin = RecibidosAdmin;
                    reporte.RecibidosActuario = RecibidosActuario;
                    reporte.RecibidosContador = RecibidosContador;
                    reporte.RecibidosEconomia = RecibidosEconomia;
                    reporte.RecibidosSistemas = RecibidosSistemas;

                    reporte.AdminCum = AdminCum;
                    reporte.AdminMagna = AdminMagna;
                    reporte.AdminSumma = AdminSumma;

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

                    reporte.AdminSinTitulo = AdminSinTitulo;
                    reporte.ActuarioSinTitulo = ActuarioSinTitulo;
                    reporte.ContadorSinTitulo = ContadorSinTitulo;
                    reporte.EconomiaSinTitulo = EconomiaSinTitulo;
                    reporte.SistemasSinTitulo = SistemasSinTitulo;



                }




                return reporte;





            }


            return reporte;





        }







    }
}
