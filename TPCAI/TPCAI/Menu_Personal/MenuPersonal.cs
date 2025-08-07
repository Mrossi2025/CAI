using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_de_Negocios;


namespace TPCAI.Menu_Personal
{
    public partial class MenuPersonal : Form
    {
        private int personalId;

        public MenuPersonal(int id)
        {
            InitializeComponent();
            personalId = id;
        }

        private void Menu_Personal_Load(object sender, EventArgs e)
        {
            var negocio = new ListaDocentes();
            var docente = negocio.ObtenerListaDocentes().FirstOrDefault(d => d.id == personalId);

            if (docente != null)
            {
                lblBienvenida.Text = $"¡Bienvenido/a, {docente.nombre} {docente.apellido}!";
            }
            else
            {
                lblBienvenida.Text = "¡Bienvenido/a!";
            }

            lblBienvenida.Left = (this.ClientSize.Width - lblBienvenida.Width) / 2;
        }

        private void btnLiquidarSueldo_Click(object sender, EventArgs e)
        {
            Liquidaciones form = new Liquidaciones(personalId, this);
            form.Show();
            this.Hide();
        }

        
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
           
            
            this.Close();
        }

        private void MenuPersonal_FormCLosed(object sender, FormClosedEventArgs e) 
        {
            Login loginForm = new Login();
            loginForm.Show();
            MessageBox.Show("Cerrando Sesión");
        }
    }
}
