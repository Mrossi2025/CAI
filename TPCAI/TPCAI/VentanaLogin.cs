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



        public int ContadorDeErrores;


        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Usuarios nuevo = new Usuarios() { NombreUsuario = "MarcosRossi1999", Contraseña = "Mnrcdvs123@", Nombre = "Marcos", Apellido = "Rossi", DNI = 42283285, Registro = 900546, Tipo = Capa_de_Negocios.Usuarios.TipoUsuario.Alumno, Estado = true };

            List<Usuarios> ListaUsuarios = new List<Usuarios>();

            ListaUsuarios.Add(nuevo);


            Login login = new Login();
            string Usuario;
            string Contraseña;
            Usuario = txtUsuario.Text;
            Contraseña = txtConstraseña.Text;
           
            string errores = "Inicio";
            if (string.IsNullOrEmpty(Usuario)) { MessageBox.Show("El campo usuario no puede estar vacio");}
            else if (string.IsNullOrEmpty(Contraseña)) { MessageBox.Show("El campo de contraseña no puede estar vacio");}
            else
            {
                errores = login.ValidarUsuario(Usuario, Contraseña, ListaUsuarios);
                if (!string.IsNullOrEmpty(errores))
                {
                    if (errores == "No se ha encontrado un usuario con ese dato.") { MessageBox.Show("El usuario no existe."); }
                    else if (errores == "La contraseña es incorrecta.") //Este else if, se podria transformar en un else solamente porque hay 2 opciones de errores por ahora
                    {
                        ContadorDeErrores++;
                        if (ContadorDeErrores < 5) { MessageBox.Show(errores + " Quedan " + (5 - ContadorDeErrores) + " Intentos."); }
                        else if (ContadorDeErrores == 5) { string MensajeDeBloqueo = login.BloquearUsuario(Usuario, ListaUsuarios); MessageBox.Show(MensajeDeBloqueo); }
                        else { MessageBox.Show("El Usuario " + Usuario + " Se encuentra bloqueado, pida ayuda a un administrador para desbloquearlo"); }


                    }
                }

                else
                {
                    Usuarios UsuarioEncontrado;
                    UsuarioEncontrado = ListaUsuarios.Find(a => a.NombreUsuario == Usuario);

                    switch (UsuarioEncontrado.Tipo)
                    {
                        case Usuarios.TipoUsuario.Alumno:
                            // Si querés pasarle el objeto para mostrar datos:
                            Menu_principal___Alumno frmAlu = new Menu_principal___Alumno(UsuarioEncontrado);
                            frmAlu.Show();
                            this.Hide();          // ocultar o this.Close();
                            break;

                        case Usuarios.TipoUsuario.Administrador:
                            MenuAdmin frmAdm = new MenuAdmin();
                            frmAdm.Show();
                            this.Close();
                            break;

                        // case Usuarios.TipoUsuario.Personal:
                        //   Menu_principal___Personal frmPer = new Menu_principal___Personal(usuarioEncontrado);
                        // frmPer.Show();
                        //this.Hide();
                        // break;

                        default:
                            MessageBox.Show("Tipo de usuario sin menú asignado.");
                            break;
                    }

                }

                
            }

            



        }
    }
}
