using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using TPCAI.Menu_Personal;
using System.Windows.Forms;
using Capa_de_Negocios;
using Datos;

namespace TPCAI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string contraseña = txtConstraseña.Text;


            if (string.IsNullOrEmpty(usuario))
            { MessageBox.Show("El campo usuario no puede estar vacio"); return; }
            if (string.IsNullOrEmpty(contraseña))
            { MessageBox.Show("El campo contraseña no puede estar vacio"); return; }


           /* if(!ValidarUsuarioYPassword(usuario, contraseña))
            {
                MessageBox.Show("Usuario y/o contraseña inválidos:\n" +
                        "- Mínimo 8 caracteres\n- Al menos 1 letra y 1 número");
            }*/

            else 
            {
                try
                {
                    LoginNegocio l = new LoginNegocio();
                    LoginResponse resp = l.login(txtUsuario.Text, txtConstraseña.Text); //llama al metodo y el metodo pide autenticación, y si es incorrecto manda la exeption que pisamos en la capa de negocios "Credenciales incorrectas"

                    switch (resp.perfilUsuario)              // Según el perfil recibido, abre el menú correspondiente "ADMIN", "PERSONAL", "ALUMNO" y se deberia llevar por parametro el id en caso de personal
                    {
                        case "ADMIN":
                            new MenuAdmin(resp.id).Show();
                            break;

                        case "PERSONAL":
                            new MenuPersonal(resp.id).Show();
                            break;

                        case "ALUMNO":
                            new MenuPrincipalAlumno(resp.id).Show();
                            break;

                        default:
                            MessageBox.Show($"Perfil desconocido: {resp.perfilUsuario}");
                            return;                          // no continúes si el tipo es inválido
                    }

                    // 4)  Si todo salió bien, ocultar (o cerrar) el login
                    this.Hide();      // ó this.Close() si usás patrón raíz = menú
                }
                catch(Exception ex)
                {
                    if(ex.Message == "Usuario bloqueado")
                    MessageBox.Show("Usuario Bloqueado",ex.ToString() ,MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else { MessageBox.Show("Credenciales invalidas", ex.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Information); }
                }

            }

        }

        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtConstraseña.UseSystemPasswordChar = true;

        }

        private void chkMostrar_CheckedChanged(object sender, EventArgs e)
        {
            txtConstraseña.UseSystemPasswordChar = !chkMostrar.Checked;
        }


        public bool ValidarUsuarioYPassword(string usuario, string contraseña)
        {

            if (usuario.Length < 8 || contraseña.Length < 8)
            { return false; }

            bool usuarioTieneLetra = false;
            bool usuarioTieneNumero = false;
            bool passTieneLetra = false;
            bool passTieneNumero = false;

            // Revisar usuario
            foreach (char c in usuario)
            {
                if (char.IsLetter(c)) usuarioTieneLetra = true;
                if (char.IsDigit(c)) usuarioTieneNumero = true;
            }

            // Revisar contraseña
            foreach (char c in contraseña)
            {
                if (char.IsLetter(c)) passTieneLetra = true;
                if (char.IsDigit(c)) passTieneNumero = true;
            }

            // Validar que ambas cumplan con letras y números
            if (usuarioTieneLetra && usuarioTieneNumero && passTieneLetra && passTieneNumero)
            { return true; }
            else
            { return false; }
        }




    }
}
