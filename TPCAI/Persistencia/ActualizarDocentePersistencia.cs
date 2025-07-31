using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Datos.Menu_Admin.ABM_DocentesClases;
using Newtonsoft.Json;
using Persistencia.utils;

namespace Persistencia.Menu_AdminPersistencia.AMB_DocentesPersistencia
{
    public class ActualizarDocentePersistencia
    {
        public string ActualizarDocente(long id, AgregarDocenteRequest docente)
        {
            // Serializar el objeto request a JSON
            string json = JsonConvert.SerializeObject(docente);

            // Armar la URL con el ID
            string url = $"tpIntensivo/docentes/{(long)id}";

            // Enviar PUT
            HttpResponseMessage resp = WebHelper.Put(url, json);

            // Manejo de error o éxito
            if (!resp.IsSuccessStatusCode)
            {
                string err = resp.Content.ReadAsStringAsync().Result;
                return err;
            }
            else
            {
                return "OK";
            }
        }
    }
}
