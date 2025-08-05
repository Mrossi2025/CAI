using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Persistencia;

namespace Capa_de_Negocios
{
    public class LiquidarSueldoNegocio
    {
        private const decimal PRECIO_HORA = 7700m;

        public decimal CalcularSueldo(Docente docente, int horas)
        {
            // Validamos el tipo
            string tipo = docente.tipo.ToUpper();
            decimal coefCargo;
            if (tipo == "PROFESOR")
                coefCargo = 1.2m;
            else if (tipo == "AYUDANTE")
                coefCargo = 1.05m;
            else if (tipo.Contains("AD HONOREM"))
                throw new Exception("El docente es Ayudante Ad Honorem. No corresponde liquidación.");
            else
                throw new Exception("Al tipo de docente no le corresponde liquidación.");

            // Calculamos coeficiente por antigüedad 
            int tramos = docente.antiguedad / 5;  // cada 5 años
            decimal coefAntiguedad = 1.1m * tramos;

            // Fórmula
            decimal sueldo = horas * PRECIO_HORA * coefCargo * coefAntiguedad;

            return sueldo;
        }
    }
}
