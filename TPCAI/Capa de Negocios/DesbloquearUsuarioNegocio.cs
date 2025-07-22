using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class DesbloquearUsuarioNegocio
    {
        public string SolicitarDesbloqueo(long idUsuario)
        {
            

            if(idUsuario<=0)
            {
                return "Id Usuario inválido";

            }

            DesbloquearUsuarioRequest DU = new DesbloquearUsuarioRequest();
            { DU.idUsuario = idUsuario; }
            DesbloquearUsuarioPersistencia req = new DesbloquearUsuarioPersistencia();

            string msj = req.DesbloquearUsuario(DU);

            if (msj == "OK")
            { return "OK"; }
            else { return "Error"; }
        }



    }
}
