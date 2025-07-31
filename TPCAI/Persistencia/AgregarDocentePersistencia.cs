using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Datos.Menu_Admin.ABM_DocentesClases;
using Newtonsoft.Json;
using Persistencia.utils;

namespace Persistencia.Menu_AdminPersistencia.AMB_DocentesPersistencia
{
    public class AgregarDocentePersistencia
    {

        public string AgregarDocente(AgregarDocenteRequest add)
        {
            // Serializar el objeto alumno ⇒ JSON
            string json = JsonConvert.SerializeObject(add);

            // Llamada POST
            HttpResponseMessage resp = WebHelper.Post("tpIntensivo/docentes", json);


            if (!resp.IsSuccessStatusCode)
            {
                string err = resp.Content.ReadAsStringAsync().Result;
                return err;
            }
            else { return "OK"; }
        }


    }



    
}
