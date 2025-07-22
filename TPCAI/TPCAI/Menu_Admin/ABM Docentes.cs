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
    public partial class ABM_Docentes : Form
    {
        MenuAdmin MenuAdmin2 = new MenuAdmin();
        
        public List<Docente> listaDocentes = new List<Docente>();


        public ABM_Docentes(MenuAdmin menuAdmin2)
        {
            InitializeComponent();
            MenuAdmin2 = menuAdmin2;
        }

        private void ABM_Docentes_FormClosed(object sender, FormClosedEventArgs e)
        {
            MenuAdmin2.Show();
        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuAdmin2.Show();
        }

        private void btnCargarDocentes_Click(object sender, EventArgs e)
        {
            ListaDocentes lst = new ListaDocentes();
            

            
                try
                {

                    listaDocentes = lst.ObtenerListaDocentes();
                    MessageBox.Show($"Lista cargada: hay {listaDocentes.Count} docentes.");


                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            
        
        
        }


    }
}
