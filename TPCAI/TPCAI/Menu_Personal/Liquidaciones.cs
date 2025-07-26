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
using Datos.Menu_Admin.ABM_DocentesClases;

namespace TPCAI
{
    public partial class Liquidaciones : Form
    {
        public Liquidaciones()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Liquidaciones_Load(object sender, EventArgs e)
        {
            CargarDocentesValidos();
        }

        private void CargarDocentesValidos()
        {
            try
            {
                // 1) Crear instancia de la capa de negocios
                ListaDocentes negocio = new ListaDocentes();

                // 2) Obtener la lista de docentes
                var docentes = negocio.ObtenerListaDocentes();

                // 3) Filtrar solo PROFESORES y AYUDANTES (excluye AYUDANTE AD HONOREM)
                var docentesValidos = docentes
                    .Where(d => d.tipo.ToUpper() == "PROFESOR" || d.tipo.ToUpper() == "AYUDANTE")
                    .ToList();

                // 4) Cargar el ComboBox con "Apellido, Nombre"
                cmbDocentes.DataSource = docentesValidos;
                cmbDocentes.DisplayMember = "apellido";  // Podés usar $"{apellido}, {nombre}" pero ahora no tenemos nombreCompleto
                cmbDocentes.ValueMember = "id";          // ID del docente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar docentes: {ex.Message}");
            }
        }

    }
}
