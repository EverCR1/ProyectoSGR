﻿using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjectSGR
{
    public partial class frmCrearReporte : Form

    {
        public List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>();
        public List<decimal> listaInge = new List<decimal>();
        Reporte reporte = new Reporte();

        public frmCrearReporte()
        {
            InitializeComponent();
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                
                e.SuppressKeyPress = true; // Evita que se escriba el salto de línea en el TextBox actual
                SelectNextControl((Control)sender, true, true, true, true);

            }

            //else if (e.KeyData == Keys.Up)
            //{
            //    e.SuppressKeyPress = true; // Evita que se escriba el salto de línea en el TextBox actual
            //    SelectNextControl((Control)sender, true, true, true, true);
            //}

        }


        //Función para crear TextBox dinámicamente
        private void crearTextBox()
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

                    var textBox = new System.Windows.Forms.TextBox

                    {
                        Location = new Point(120, 30 * i),
                        Width = 100
                    };

                    textBox.KeyDown += TextBox_KeyDown;

                    // Asocia el evento TextChanged a una función de suma
                    textBox.TextChanged += TextBox_TextChanged;

                    // Agrega los nuevos controles al panel
                    textBoxes.Add(textBox);
                    panelViajes.Controls.Add(label);
                    panelViajes.Controls.Add(textBox);
                    //listaInge.Add(0);

                }

            }
            else
            {
                MessageBox.Show("Ingrese una cantidad válida de viajes");
            }
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalIngresos();

            //System.Windows.Forms.TextBox textBoxe = (System.Windows.Forms.TextBox)sender;
            //decimal valor = decimal.Parse(textBoxe.Text);
            //listaInge.Add(valor);
        }

        private void btnAddViajes_Click(object sender, EventArgs e)
        {
            panelViajes.Visible = true;
            crearTextBox();
            btnLimpiar.Visible = true;
        }


        private void CalcularTotalIngresos()
        {
            decimal totalIngresos = 0;

            foreach (var textBox in textBoxes)
            {
                if (decimal.TryParse(textBox.Text, out decimal ingreso))
                {
                    totalIngresos += ingreso;
                    
                }
            }

            txtTotalIngresos.Text = totalIngresos.ToString("0.00");
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

            if (e.KeyChar == (char)Keys.Enter)
            { 
                txtAyudante.Focus();
                e.Handled = true; 
            }
        }

        private void txtCombustible_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtViaticos.Focus();
                e.Handled = true;
            }
        }

        private void txtAyudante_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtCombustible.Focus();
                e.Handled = true;
            }
        }

        private void txtViaticos_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }
            if (e.KeyChar == (char)Keys.Enter)
            {
                txtExtras.Focus();
                e.Handled = true;
            }
        }

        private void txtExtras_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
                return;
            }

            // Verifica si el punto decimal ya se ha ingresado.
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
                return;
            }

            // Verifica si se ha ingresado más de dos decimales.
            if ((sender as System.Windows.Forms.TextBox).Text.Contains('.') 
                && (sender as System.Windows.Forms.TextBox).Text.Split('.')[1].Length >= 2)
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == (char)Keys.Enter)
            {
                txtComentario.Focus();
                e.Handled = true;
            }

        }


        private void btnCrear_Click(object sender, EventArgs e)
        {

            bool errorMostrado = false;
            listaInge.Clear(); //Limpia la lista

            // Recorre los TextBox dinámicos y registra sus valores en la lista
            foreach (Control control in panelViajes.Controls)
            {
                if (control is System.Windows.Forms.TextBox textBox)
                {
                    if (decimal.TryParse(textBox.Text, out decimal valor))
                    {
                        listaInge.Add(valor);
                    }
                    else
                    {
                        if (!errorMostrado)
                        {
                            MessageBox.Show("Por favor, ingrese un valor correcto en los Ingresos",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            errorMostrado=true;
                        }
                        
                    }
                }
            }

            if (VerificarTextBoxLlenos())
            {
                //Obtenemos los valores del formulario
                reporte.CantViajes = int.Parse(txtCantViajes.Text);
                reporte.IdVehiculo = (int)cBoxVehiculo.SelectedValue;
                reporte.Fecha = datePick.Value;
                reporte.Turno = (int)nTurno.Value;
                reporte.PagoPiloto = int.Parse(txtPiloto.Text);
                reporte.PagoAyudante = int.Parse(txtAyudante.Text);
                reporte.PagoCombustible = int.Parse(txtCombustible.Text);
                reporte.PagoViaticos = int.Parse(txtViaticos.Text);
                reporte.PagoExtras = decimal.Parse(txtExtras.Text);
                reporte.TotalIngresos = decimal.Parse(txtTotalIngresos.Text);
                reporte.TotalEgresos = decimal.Parse(txtTotalEgresos.Text);
                reporte.Capital = decimal.Parse(txtCapital.Text);
                reporte.Comentario = txtComentario.Text;
                reporte.IdUsuario = 1;
                reporte.Listado = listaInge;

                reporte.CrearReporte();

                foreach (int valor in listaInge)
                {
                    Console.WriteLine(valor);
                }

                this.Close();
            }
            else
            {
                MessageBox.Show("Por favor, debe llenar todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CalcularTotalEgresos()
        {
            decimal totalPagos = 0;

            if (int.TryParse(txtPiloto.Text, out int pagoPiloto))
            {
                totalPagos += pagoPiloto;
            }
            if (int.TryParse(txtAyudante.Text, out int pagoAyudante))
            {
                totalPagos += pagoAyudante;
            }
            if (int.TryParse(txtCombustible.Text, out int pagoCombustible))
            {
                totalPagos += pagoCombustible;
            }
            if (int.TryParse(txtViaticos.Text, out int pagoViaticos))
            {
                totalPagos += pagoViaticos;
            }
            if (decimal.TryParse(txtExtras.Text, out decimal pagoExtras))
            {
                totalPagos += pagoExtras;
            }

            txtTotalEgresos.Text = totalPagos.ToString("0.00");
            
        }

        private void txtPiloto_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalEgresos(); 
        }

        private void txtAyudante_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalEgresos(); 
        }

        private void txtCombustible_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalEgresos();
        }

        private void txtViaticos_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalEgresos();
        }

        private void txtExtras_TextChanged(object sender, EventArgs e)
        {
            CalcularTotalEgresos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTotalIngresos_TextChanged(object sender, EventArgs e)
        {
            CalcularCapital();
        }

        private void txtTotalEgresos_TextChanged(object sender, EventArgs e)
        {
            CalcularCapital();
        }

        private void CalcularCapital()
        {
            if (decimal.TryParse(txtTotalIngresos.Text, out decimal totalIngresos) &&
                decimal.TryParse(txtTotalEgresos.Text, out decimal totalEgresos))
            {
                decimal capital = totalIngresos - totalEgresos;
                txtCapital.Text = capital.ToString("0.00");
            }
            else
            {
                txtCapital.Text = ""; // Deja el TextBox de "Capital" en blanco si no se pueden analizar los valores.
            }
        }

        //Función para verificar que todos los campos requeridos estén llenos llenos
        private bool VerificarTextBoxLlenos()
        {

            if (!string.IsNullOrWhiteSpace(txtPiloto.Text) &&
                !string.IsNullOrWhiteSpace(txtAyudante.Text) &&
                !string.IsNullOrWhiteSpace(txtCombustible.Text) &&
                !string.IsNullOrWhiteSpace(txtViaticos.Text) &&
                !string.IsNullOrWhiteSpace(txtCantViajes.Text)
            )
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        private void txtCantViajes_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true; // Bloquea la tecla presionada
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            panelViajes.Controls.Clear();
            btnLimpiar.Visible = false;
        }
        //prueba
        private void txtComentario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnCrear.Focus();
                e.Handled = true;
            }
        }
    }
}
