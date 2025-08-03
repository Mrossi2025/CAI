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
using Capa_de_Negocios.Menu_Personal;
using Datos.Menu_Admin.ABM_DocentesClases;

namespace TPCAI
{
    public partial class Liquidaciones : Form
    {
        private int personalId;
        private Form _formAnterior;
        public Liquidaciones(int id, Form formAnterior)
        {
            InitializeComponent();
            personalId = id;
            _formAnterior = formAnterior;

            // Bloquear campos de datos
            txtNombre.ReadOnly = true;
            txtApellido.ReadOnly = true;
            txtDNI.ReadOnly = true;
            txtAntiguedad.ReadOnly = true;
            rbtnProfesor.Enabled = false;
            rbtnAyudante.Enabled = false;            
        }
        private void Liquidaciones_Load(object sender, EventArgs e)
        {
            CargarDatosDocentePorId();
        }
        
        private Docente _docente;
        private void CargarDatosDocentePorId()
        {
            try
            {
                ListaDocentes negocio = new ListaDocentes();
                var docentes = negocio.ObtenerListaDocentes();

                _docente = docentes.FirstOrDefault(d => d.id == personalId);

                if (_docente == null)
                {
                    MessageBox.Show("No se encontró al personal.");
                    return;
                }

                txtNombre.Text = _docente.nombre;
                txtApellido.Text = _docente.apellido;
                txtDNI.Text = _docente.dni;
                txtAntiguedad.Text = _docente.antiguedad.ToString();

                if (_docente.tipo.ToUpper() == "PROFESOR")
                    rbtnProfesor.Checked = true;
                else if (_docente.tipo.ToUpper() == "AYUDANTE")
                    rbtnAyudante.Checked = true;
                else
                    MessageBox.Show("Este perfil no corresponde a un cargo liquidable.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}");
            }
        }

        private void btnLiquidar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_docente == null)
                {
                    MessageBox.Show("No se encontró el docente.");
                    return;
                }

                if (!int.TryParse(txtHoras.Text, out int horas) || horas <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de horas.");
                    return;
                }
                // La consigna no establece un tope, pero esto ayuda a prevenir errores de carga excesiva
                if (horas > 240)
                {
                    MessageBox.Show("No se pueden liquidar más de 240 horas. Verifique los datos.");
                    return;
                }

                var negocio = new LiquidarSueldoNegocio();
                decimal sueldo = negocio.CalcularSueldo(_docente, horas);

                MessageBox.Show($"Sueldo a liquidar: ${sueldo:N2}", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool _cerrandoDesdeBotonVolver = false;
        private void btnVolver_Click(object sender, EventArgs e)
        {
            _cerrandoDesdeBotonVolver = true;
            _formAnterior.Show();
            this.Close();
        }

        private void Liquidaciones_FormCLosed(object sender, FormClosedEventArgs e)
        {
            if (!_cerrandoDesdeBotonVolver)
            {
                Application.Exit();
            }
        }

    }
}
