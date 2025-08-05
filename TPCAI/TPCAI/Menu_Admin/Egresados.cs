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
            List<AlumnosRecibidos> reporte = new List<AlumnosRecibidos>();
            GenerarReporteNegocio grn = new GenerarReporteNegocio();
            try
            {
                reporte = grn.Reportenuevo();


                dgvReporte.DataSource = reporte; ;
                MessageBox.Show("Reporte generado con exito.");

            }
            catch (Exception ex) {MessageBox.Show(ex.Message); }


            // Lista de carreras fijas
            string[] carreras = { "Administración", "Actuario", "Contador", "Economía", "Sistemas" };

            // Lista de títulos honoríficos
            string[] titulos = { "Summa Cum Laude", "Magna Cum Laude", "Cum Laude", "Sin título honorífico" };

            // Crear DataTable para mostrar en el DataGridView
            DataTable tablaResumen = new DataTable();
            tablaResumen.Columns.Add("Carrera");
            tablaResumen.Columns.Add("Total", typeof(int));
            tablaResumen.Columns.Add("Summa Cum Laude", typeof(int));
            tablaResumen.Columns.Add("Magna Cum Laude", typeof(int));
            tablaResumen.Columns.Add("Cum Laude", typeof(int));
            tablaResumen.Columns.Add("Sin título honorífico", typeof(int));

            // Recorrer cada carrera y contar
            foreach (string carrera in carreras)
            {
                int total = 0;
                int sumaSumma = 0;
                int sumaMagna = 0;
                int sumaCum = 0;
                int sumaSin = 0;

                foreach (var alumno in reporte)
                {
                    if (alumno.carrera == carrera)
                    {
                        total++;

                        if (alumno.titulo == "Summa Cum Laude")
                            sumaSumma++;
                        else if (alumno.titulo == "Magna Cum Laude")
                            sumaMagna++;
                        else if (alumno.titulo == "Cum Laude")
                            sumaCum++;
                        else if (alumno.titulo == "Sin título honorífico")
                            sumaSin++;
                    }
                }

                // Agregar fila al DataTable
                tablaResumen.Rows.Add(carrera, total, sumaSumma, sumaMagna, sumaCum, sumaSin);
            }

            // Asignar al DataGridView
            dgvReporteGeneral.DataSource = tablaResumen;








        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAdmin2.Show();
        }

        
    }
}
