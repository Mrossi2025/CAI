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
            cmbDocentes.SelectedIndexChanged += cmbDocentes_SelectedIndexChanged; //dispara automáticamente el sistema
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

                // 4) Cargar el ComboBox 
                cmbDocentes.DataSource = docentesValidos;
                cmbDocentes.DisplayMember = "DocenteCompleto";
                cmbDocentes.ValueMember = "id"; // ID del docente
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar docentes: {ex.Message}");
            }
        }

        //Completa los datos según profesor elegido
        private void cmbDocentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDocentes.SelectedItem is Docente docente)
            {
                txtNombre.Text = docente.nombre;
                txtApellido.Text = docente.apellido;
                txtDNI.Text = docente.dni;
                txtAntiguedad.Text = docente.antiguedad.ToString();

                if (docente.tipo.ToUpper() == "PROFESOR")
                    rbtnProfesor.Checked = true;
                else if (docente.tipo.ToUpper() == "AYUDANTE")
                    rbtnAyudante.Checked = true;
            }
        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Validar selección de docente
                if (cmbDocentes.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, seleccione un docente.");
                    return;
                }

                // 2) Validar horas ingresadas
                if (!int.TryParse(txtHoras.Text, out int horas) || horas <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de horas.");
                    return;
                }

                // 3) Obtener docente seleccionado
                Docente docenteSeleccionado = (Docente)cmbDocentes.SelectedItem;

                // 4) Llamar a capa de negocio para calcular sueldo
                var negocio = new LiquidarSueldoNegocio();
                decimal sueldo = negocio.CalcularSueldo(docenteSeleccionado, horas);

                // 5) Mostrar resultado
                MessageBox.Show($"Sueldo a liquidar: ${sueldo:N2}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al calcular sueldo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
