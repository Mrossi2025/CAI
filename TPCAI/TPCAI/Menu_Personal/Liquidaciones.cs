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

            txtHorasSistema.Enabled = false;
            btnLiquidar.Enabled = false; 
            txtHoras.Enabled = false;
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
                txtSueldo.Text = sueldo.ToString();
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

        

        

        


        

        private async void btnCargar_Click(object sender, EventArgs e)
        {
            HorasDocenteNegocio hdn = new HorasDocenteNegocio();

            // Desactivar botón y mostrar "Cargando..."
            btnCargar.Enabled = false;
            btnCargar.Text = "Cargando...";

            try
            {
                // Ejecutar tarea pesada en segundo plano
                double horas = await Task.Run(() => hdn.HorasDocente(personalId));

                // Mostrar resultado en el textbox (ya en el hilo de UI)
                txtHorasSistema.Text = horas.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error cargando las horas");
            }
            finally
            {
                // Restaurar el botón al estado original
                btnCargar.Enabled = true;
                btnCargar.Text = "Cargar horas";
            }

        }


        

        private void chkManualHoras_CheckedChanged(object sender, EventArgs e)
        {
            if (chkManualHoras.Checked)
            {
                btnLiquidar.Enabled = true;
                txtHoras.Enabled = true;
            }
            else { btnLiquidar.Enabled = false;
            txtHoras.Enabled = false;}

        }

        private void btnLiquidar3_Click(object sender, EventArgs e)
        {
            try
            {
                if (_docente == null)
                {
                    MessageBox.Show("No se encontró el docente.");
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtHorasSistema.Text))
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
                txtSueldo.Text = sueldo.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
