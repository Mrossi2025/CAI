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
using Datos;

namespace TPCAI
{
    public partial class Menu_principal___Alumno : Form
    {

        
        


        public Menu_principal___Alumno(int idAlumno) //Constructor que recibe el parametro del usuario que ingresa para ya tener sus datos a mano.
        {
            int IdAlumno;

            InitializeComponent();
            IdAlumno = idAlumno;

            lblBienvenida.Text = $"Bienvenido/a {IdAlumno}"; //Da la bienvenida con el dato del usuario que traje por parametros.

        }

       



        public Menu_principal___Alumno()
        {
            InitializeComponent();
        }

       

        private void Menu_principal___Alumno_FormClosed_1(object sender, FormClosedEventArgs e)
        {
            MessageBox.Show("Sesion Cerrada");
            VentanaLogin formLogin = new VentanaLogin();
            formLogin.Show();
        }
    }
}
