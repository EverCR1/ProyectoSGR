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
            Reporte reporte = new Reporte();

            btnRegresar.Visible = true;
            panelViajes.Visible = true;
            
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
                        Location = new Point(120, 30 * i),
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

            else if (e.KeyData == Keys.Up)
            {
                e.SuppressKeyPress = true; // Evita que se escriba el salto de línea en el TextBox actual
                SelectNextControl((Control)sender, true, true, true, true);
            }

        }

        private void frmCrearReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bdSGRDataSet.tbVehiculo' Puede moverla o quitarla según sea necesario.
            this.tbVehiculoTableAdapter.Fill(this.bdSGRDataSet.tbVehiculo);

        }

        private void txtPiloto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }
        }

        private void txtCombustible_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }
        }

        private void txtAyudante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }
        }

        private void txtViaticos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }
        }

        private void txtExtras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }
            
        }

        private void txtTotalIngresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }

            
        }

        private void txtTotalEgresos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            panelReporte.Visible = true;
            panelViajes.Visible = false;
            btnRegresar.Visible = false;
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Reporte reporte = new Reporte();
            
            //Obtenemos los valores del formulario
            reporte.IdVehiculo = (int)cBoxVehiculo.SelectedValue;
            reporte.Fecha = datePick.Value;
            reporte.Turno = (int)nTurno.Value;
            reporte.PagoPiloto = int.Parse(txtPiloto.Text);
            //reporte.PagoAyudante = int.Parse(txtAyudante.Text);
            //reporte.PagoCombustible = int.Parse(txtCombustible.Text);
            //reporte.PagoViaticos = int.Parse(txtViaticos.Text);
            reporte.PagoExtras = decimal.Parse(txtExtras.Text);
            //reporte.TotalIngresos = decimal.Parse(txtTotalIngresos.Text);
            //reporte.TotalEgresos = decimal.Parse(txtTotalEgresos.Text);
            //reporte.Capital = decimal.Parse(txtCapital.Text);
            //reporte.Comentario = txtComentario.Text;
            //reporte.IdUsuario = 1;

            Console.WriteLine(reporte.IdVehiculo);
            Console.WriteLine(reporte.Fecha);
            Console.WriteLine(reporte.Turno);
            Console.WriteLine(reporte.PagoPiloto);
            Console.WriteLine(reporte.PagoExtras);
            Console.WriteLine("Prueba");

            this.Close();
        }
    }
}
