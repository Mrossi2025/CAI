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
            VentanaLogin ventanaLogin = new VentanaLogin();
            ventanaLogin.Show();
            MessageBox.Show("Sesion cerrada");
        }
    }
}
