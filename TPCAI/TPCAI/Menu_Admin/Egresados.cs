using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_de_Negocios;
using Datos;

namespace TPCAI
{
    public partial class Menu_Egresados : Form
    {

        MenuAdmin MenuAdmin2 = new MenuAdmin();


        public Menu_Egresados(MenuAdmin menuAdmin2)
        {
            InitializeComponent();
            MenuAdmin2 = menuAdmin2;
        }

        private void Menu_Egresados_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuAdmin2.Show();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            GenerarReporteNegocio grn = new GenerarReporteNegocio();
            try
            {
                reporte = grn.Reportenuevo();

                List<ReporteFila> tabla = new List<ReporteFila>
{
                    new ReporteFila
                    {
                        Carrera = "Administración",
                        Recibidos = reporte.RecibidosAdmin,
                        Cum = reporte.AdminCum,
                        Magna = reporte.AdminMagna,
                        Summa = reporte.AdminSumma,
                        SinTituloHonorifico = reporte.AdminSinTitulo
                    },
                    new ReporteFila
                    {
                        Carrera = "Actuario",
                        Recibidos = reporte.RecibidosActuario,
                        Cum = reporte.ActuarioCum,
                        Magna = reporte.ActuarioMagna,
                        Summa = reporte.ActuarioSumma,
                        SinTituloHonorifico = reporte.ActuarioSinTitulo
                    },
                    new ReporteFila
                    {
                        Carrera = "Contador",
                        Recibidos = reporte.RecibidosContador,
                        Cum = reporte.ContadorCum,
                        Magna = reporte.ContadorMagna,
                        Summa = reporte.ContadorSumma,
                        SinTituloHonorifico = reporte.ContadorSinTitulo
                     },
                    new ReporteFila
                    {
                        Carrera = "Economía",
                        Recibidos = reporte.RecibidosEconomia,
                        Cum = reporte.EconomiaCum,
                        Magna = reporte.EconomiaMagna,
                        Summa = reporte.EconomiaSumma,
                        SinTituloHonorifico = reporte.EconomiaSinTitulo
                    },
                    new ReporteFila
                    {
                        Carrera = "Sistemas",
                        Recibidos = reporte.RecibidosSistemas,
                        Cum = reporte.SistemasCum,
                        Magna = reporte.SistemasMagna,
                        Summa = reporte.SistemasSumma,
                        SinTituloHonorifico = reporte.SistemasSinTitulo
                    }


                };

                dgvReporte.DataSource = tabla;
                MessageBox.Show("Reporte generado con exito.");

            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }


        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAdmin2.Show();
        }
    }
}
