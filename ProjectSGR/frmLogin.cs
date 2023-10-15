using ProjectSGR.bdSGRDataSetTableAdapters;
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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            QueriesTableAdapter adapter = new QueriesTableAdapter();

            int? idU = (int?)adapter.Flogin(txtUser.Text, txtPass.Text);
            if (idU > 0)
            {
                this.Close();
                //Variables.logeado = Convert.ToInt32(idU);
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecta");
                //Variables.logeado = 0;
            }

            txtUser.Focus();
        }

        private void txtUser_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                txtPass.Focus();
            }
        }

        private void txtPass_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnAceptar.Focus();
            }
        }
    }
}
