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

namespace TPCAI
{
    public partial class DesbloquearUsuario : Form
    {

        private MenuAdmin menuAdmin;
        private DesbloquearUsuarioNegocio desbloquear;

        public DesbloquearUsuario(MenuAdmin form)
        {
            InitializeComponent();
            menuAdmin = form;
            desbloquear = new DesbloquearUsuarioNegocio();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            menuAdmin.Show();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtIdUsuario.Clear();
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            long id ;

            if ( !long.TryParse(txtIdUsuario.Text,out id))
            { MessageBox.Show("Ingrese un ID numérico válido."); return; } //return para cortar
            if (id < 0)
            { MessageBox.Show("El ID no puede ser negativo");return; }
            
                string resp = desbloquear.SolicitarDesbloqueo(id);

            
            if (resp == "OK")
            { MessageBox.Show("Usuario desbloqueado exitosamente", resp); }
            else { MessageBox.Show("Ha ocurrido un error",resp); }

        }

        private void DesbloquearUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            menuAdmin.Show();
        }
    }
}
