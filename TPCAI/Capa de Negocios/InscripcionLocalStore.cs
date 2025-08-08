using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Datos;

namespace Capa_de_Negocios
{
    

    public static class InscripcionLocalStore
    {
        // AlumnoId -> Cursos elegidos
        private static readonly Dictionary<int, List<Cursos>> _inscripciones = new Dictionary<int, List<Cursos>>();

        public static void Confirmar(int alumnoId, List<Cursos> cursos)
        {
            if (!_inscripciones.ContainsKey(alumnoId))
                _inscripciones[alumnoId] = new List<Cursos>();

            // Evitar duplicados por id
            foreach (var c in cursos)
            {
                if (_inscripciones[alumnoId].All(x => x.id != c.id))
                    _inscripciones[alumnoId].Add(c);
            }
        }

        public static List<Cursos> Obtener(int alumnoId)
        {
            if (_inscripciones.TryGetValue(alumnoId, out var lista))
                return lista.ToList(); // copia

            return new List<Cursos>();
        }

        public static void Limpiar(int alumnoId)
        {
            if (_inscripciones.ContainsKey(alumnoId))
                _inscripciones[alumnoId].Clear();
        }

        private static readonly Dictionary<int, List<MateriaInscriptaDTO>> _finales = new Dictionary<int, List<MateriaInscriptaDTO>>();

        public static void ConfirmarFinales(int alumnoId, List<MateriaInscriptaDTO> finales)
        {
            if (!_finales.ContainsKey(alumnoId))
                _finales[alumnoId] = new List<MateriaInscriptaDTO>();

            foreach (var f in finales)
            {
                if (_finales[alumnoId].All(x => x.id != f.id))
                    _finales[alumnoId].Add(f);
            }
        }

        public static List<MateriaInscriptaDTO> ObtenerFinales(int alumnoId)
        {
            if (_finales.TryGetValue(alumnoId, out var lista))
                return lista.ToList();

            return new List<MateriaInscriptaDTO>();
        }

        public static void LimpiarFinales(int alumnoId)
        {
            if (_finales.ContainsKey(alumnoId))
                _finales[alumnoId].Clear();
        }
    }

}
