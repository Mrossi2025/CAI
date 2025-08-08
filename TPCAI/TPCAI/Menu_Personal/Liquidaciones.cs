using Capa_de_Negocios;
using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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

            // Traer horas automáticamente desde la capa de negocio
            HorasDocenteNegocio hdn = new HorasDocenteNegocio();
            double horas = 0;
            try
            {
                horas = hdn.HorasDocente(personalId);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando las horas: {ex.Message}");
            }

            txtHoras.Text = horas.ToString();
            txtHoras.Enabled = false;

            // Calcular sueldo automáticamente
            if (_docente != null && horas > 0)
            {
                var negocio = new LiquidarSueldoNegocio();
                decimal sueldo = negocio.CalcularSueldo(_docente, (int)horas);
                txtSueldo.Text = sueldo.ToString("N2");
            }
            else
            {
                txtSueldo.Text = "0";
            }

            btnLiquidar.Enabled = false; // No hace falta liquidar manualmente
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

        
        private void btnVolver_Click(object sender, EventArgs e)
        {
         
            this.Close();
        }

        private void Liquidaciones_FormCLosed(object sender, FormClosedEventArgs e)
        {
            _formAnterior.Show();
            
        }

        private void chkManual_CheckedChanged(object sender, EventArgs e)
        {
            bool habilitar = chkManual.Checked;

            btnLiquidar.Enabled = habilitar;
            txtHoras.Enabled = habilitar;
        }

        private void btnLiquidar2_Click(object sender, EventArgs e)
        {
            try
            {
                if (_docente == null)
                {
                    MessageBox.Show("No se encontró el docente.");
                    return;
                }
                if(string.IsNullOrWhiteSpace(txtHorasSistema.Text))
                {
                    MessageBox.Show("Debe cargar primero las horas.");
                    return;
                }

                //esto no hace falta porque viene por sistema. Pero lo dejo
                if (!int.TryParse(txtHorasSistema.Text, out int horas) || horas <= 0)
                {
                    MessageBox.Show("Ingrese una cantidad válida de horas.");
                    return;
                }
                // La consigna no establece un tope, pero esto ayuda a prevenir errores de carga excesiva
                if (horas > 240)
                {
                    MessageBox.Show("No se pueden liquidar más de 240 horas. Por favor solicite que se verifiquen los datos.");
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

        private void btnCargarHoras_Click(object sender, EventArgs e)
        {
            HorasDocenteNegocio hdn = new HorasDocenteNegocio();

            try
            {
                double horas = hdn.HorasDocente(personalId);

                txtHorasSistema.Text = horas.ToString();

            }
            catch (Exception ex) { MessageBox.Show($"Error: {ex.Message}", "Error cargando las horas"); }


        }

        private void lblIngresarHoras_Click(object sender, EventArgs e)
        {

        }
    }
}
