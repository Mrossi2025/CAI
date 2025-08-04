using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Newtonsoft.Json;
using Persistencia.utils;

namespace Persistencia
{
    public class CargarMateriasCarreraPersistencia
    {
        public List<Materias> cargarMateriasCarrera(long id)
        {
            // Armar la URL con el ID
            string url = $"tpIntensivo/materias/{id}";

            // Enviar PUT
            HttpResponseMessage resp = WebHelper.Get(url);

            // Manejo de error
            if (!resp.IsSuccessStatusCode)
                throw new Exception($"[{(int)resp.StatusCode}] {resp.ReasonPhrase}");

            // Leer el JSON que devuelve el endpoint
            string json = resp.Content.ReadAsStringAsync().Result;

            // Deserializar a lista de Materias
            List<Materias> materias = JsonConvert.DeserializeObject<List<Materias>>(json);

            // Si la API devuelve null, devolvemos una lista vacía
            return materias ?? new List<Materias>();



        }

    }
}
