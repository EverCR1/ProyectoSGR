using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSGR
{
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Activated(object sender, EventArgs e)
        {

        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            frmLogin frmLogin = new frmLogin();
            frmLogin.ShowDialog();
        }

        private void crearReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrearReporte frmCrearReporte = new frmCrearReporte();
            frmCrearReporte.ShowDialog();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            frmLogin cerrarLogin = new frmLogin();
            cerrarLogin.ShowDialog();
            this.Close();

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCrearUsuario frmCrearUsuario = new frmCrearUsuario();    
            frmCrearUsuario.ShowDialog();
        }

        private void editarUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditarUsuario frmEditarUsuario = new frmEditarUsuario(); 
            frmEditarUsuario.ShowDialog();

        private void editarReporteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVerReporte frmVerReporte = new frmVerReporte();
            frmVerReporte.ShowDialog();

        }
    }
}
