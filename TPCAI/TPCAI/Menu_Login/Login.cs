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
            { MessageBox.Show("El campo usuario no puede estar vacio"); }
            else if (string.IsNullOrEmpty(contraseña))
            { MessageBox.Show("El campo contraseña no puede estar vacio"); }
            else 
            {
                try
                {
                    Capa_de_Negocios.Login capaNegocio = new Capa_de_Negocios.Login();//Instancia de la capa de negocio
                    Datos.LoginResponse resp = capaNegocio.login(txtUsuario.Text, txtConstraseña.Text); //llama al metodo y el metodo pide autenticación, y si es incorrecto manda la exeption que pisamos en la capa de negocios "Credenciales incorrectas"

                    switch (resp.perfilUsuario)              // Según el perfil recibido, abre el menú correspondiente "ADMIN", "PERSONAL", "ALUMNO" y se deberia llevar por parametro el id en caso de personal
                    {
                        case "ADMIN":
                            new MenuAdmin(resp.id).Show();
                            break;

                        case "PERSONAL":
                            new MenuPersonal(resp.id).Show();
                            break;

                        case "ALUMNO":
                            new Menu_principal___Alumno(resp.id).Show();
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
                    MessageBox.Show(ex.Message,"Credenciales inválidas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }

        }

        private void VentanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
