using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;
namespace Capa_de_Negocios
{
    public class ListaAlumnos
    {
        RepositorioAlumno Repo = new RepositorioAlumno();

        public List<Alumnos> TraerAlumnos() //Creamos el metodo que van a llamar desde el front para cargar una lista en pantalla.
        {

            var lista = Repo.ObtenerAlumnos(); //asignamos la lista que se recupera desde persistencia a "lista"
             
            return lista; //el metodo devuelve la lista
        }



    }
}
