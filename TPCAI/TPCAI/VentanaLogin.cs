using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_de_Negocios;

namespace TPCAI
{
    public partial class VentanaLogin : Form
    {
        public VentanaLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            string Usuario;
            string Contraseña;
            Usuario = txtUsuario.Text;
            Contraseña = txtConstraseña.Text;
            int ContadorDeErrores;
            string errores = "Inicio";
            if (string.IsNullOrEmpty(Usuario)) { MessageBox.Show("El campo usuario no puede estar vacio");}
            else if (string.IsNullOrEmpty(Contraseña)) { MessageBox.Show("El campo de contraseña no puede estar vacio");}
            else
            {
                errores = login.ValidarUsuario(Usuario, Contraseña, out ContadorDeErrores);
                if (!string.IsNullOrEmpty(errores))
                { if (ContadorDeErrores < 5) { MessageBox.Show(errores); } else { Bloquear usuario } }
                else {  //INgresar segun rol }


            }





        }
    }
}
