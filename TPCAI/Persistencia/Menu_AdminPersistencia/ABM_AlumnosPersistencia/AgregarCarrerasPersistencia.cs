using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Persistencia.utils;
using Datos;
using System.Collections;
using System.Diagnostics;

namespace Persistencia
{
    public class AgregarCarrerasPersistencia
    {
        public List<CarrerasResponse> ObtenerTodas()
        {
            // 1) Llamar al servicio REST (usa tu WebHelper)
            HttpResponseMessage resp = WebHelper.Get("tpIntensivo/carreras");

            // 2) Validar que responda 200-299
            if (!resp.IsSuccessStatusCode)
                throw new Exception(
                    $"[{(int)resp.StatusCode}] {resp.ReasonPhrase}");

            // 3) Leer el JSON
            string json = resp.Content.ReadAsStringAsync().Result;

            // 4) Deserializar a lista
            List<CarrerasResponse> lista =
            JsonConvert.DeserializeObject<List<CarrerasResponse>>(json) ?? new List<CarrerasResponse>();

            System.Diagnostics.Debug.WriteLine($"Lista count: {lista.Count}");   // ← NUEVO
            //Si ves “Lista count: 5” en la ventana Salida(Debug), la lista está bien.


            // 5) Devolver la lista (puede estar vacía, pero nunca null)
            return lista;
        }


    }
}
