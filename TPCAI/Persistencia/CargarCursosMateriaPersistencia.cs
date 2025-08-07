using System;
using System.Collections.Generic;
using System.Net.Http;
using Datos.Menu_Admin.ABM_DocentesClases;
using Newtonsoft.Json;
using Persistencia.utils;

namespace Persistencia
{
    public class CargarCursosMateriaPersistencia
    {
        public List<Cursos> cargarCursosMateria(long idMateria)
        {
            string url = $"tpIntensivo/cursos/{idMateria}";
            HttpResponseMessage resp = WebHelper.Get(url);

            if (!resp.IsSuccessStatusCode)
                throw new Exception($"[{(int)resp.StatusCode}] {resp.ReasonPhrase}");

            string json = resp.Content.ReadAsStringAsync().Result;
            List<Cursos> cursos = JsonConvert.DeserializeObject<List<Cursos>>(json);
            return cursos ?? new List<Cursos>();
        }
    }
}
