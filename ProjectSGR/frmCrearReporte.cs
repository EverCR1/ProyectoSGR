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
    public partial class frmCrearReporte : Form
    {
        public frmCrearReporte()
        {
            InitializeComponent();
        }

        private void btnAddViajes_Click(object sender, EventArgs e)
        {
            // Captura la cantidad ingresada por el usuario en el TextBox
            if (int.TryParse(txtCantViajes.Text, out int cantidadViajes))
            {
                // Limpia cualquier TextBox previamente creado
                panelViajes.Controls.Clear();

                // Crea dinámicamente TextBox para las ganancias por cada viaje
                for (int i = 1; i <= cantidadViajes; i++)
                {
                    var label = new Label
                    {
                        Text = "Ingresos Viaje " + i + ":",
                        Location = new Point(10, 30 * i)
                        
                    };

                    var textBox = new TextBox
                    {
                        Location = new Point(100, 30 * i),
                        Width = 100
                    };

                    textBox.KeyDown += TextBox_KeyDown;

                    // Agrega los nuevos controles al panel
                    panelViajes.Controls.Add(label);
                    panelViajes.Controls.Add(textBox);
                }
            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida de viajes");
            }
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Evita que se escriba el salto de línea en el TextBox actual
                SelectNextControl((Control)sender, true, true, true, true);
            }
        }
    }
}
