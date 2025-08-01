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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
        }

       public MenuAdmin(int idAdmin)
        {
            int Idadmin = idAdmin;
            InitializeComponent();

        }

        private void MenuAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Login ventanaLogin = new Login();
            ventanaLogin.Show();
            MessageBox.Show("Sesion cerrada");
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {

            MessageBox.Show("Sesión cerrada");
            this.Close();
        }

        private void btnDesbloquearUsuario_Click(object sender, EventArgs e)
        {
            DesbloquearUsuario menuDesbloquear = new DesbloquearUsuario(this);
            menuDesbloquear.Show();
            this.Hide();
        }

        private void btnAbmAlumnos_Click(object sender, EventArgs e)
        {
            MenuAdmin1 ABMAlumnos = new MenuAdmin1(this);
            ABMAlumnos.Show();
            this.Hide();
        }

        private void btmAbmDocentes_Click(object sender, EventArgs e)
        {
            ABM_Docentes ABMDocentes = new ABM_Docentes(this);
            ABMDocentes.Show();
            this.Hide();
        }

        private void btnLiquidaciones_Click(object sender, EventArgs e)
        {
            Liquidaciones Liquidaciones = new Liquidaciones();
            Liquidaciones.Show();
            this.Hide();
        }

        private void btnEgresados_Click(object sender, EventArgs e)
        {
            Menu_Egresados menuEgresados = new Menu_Egresados(this);    
            menuEgresados.Show();
            this.Hide();
        }

        private void MenuAdmin_Load(object sender, EventArgs e)
        {

        }

        private void grpMenuAdmin_Enter(object sender, EventArgs e)
        {

        }
    }
}
