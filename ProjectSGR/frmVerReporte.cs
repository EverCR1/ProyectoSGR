﻿using ProjectSGR.bdSGRDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ProjectSGR
{
    public partial class frmVerReporte : Form
    {

        Reporte reporte = new Reporte();
        pListarIngresosTableAdapter listaIngresos = new pListarIngresosTableAdapter();
        
        
        public frmVerReporte()
        {
            InitializeComponent();
        }

        private void frmVerReporte_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'bdSGRDataSet.tbReporte' Puede moverla o quitarla según sea necesario.
            //this.tbReporteTableAdapter.Fill(this.bdSGRDataSet.tbReporte);
            MostrarDatos();

        }

        private void MostrarDatos()
        {
            datosRep.DataSource = reporte.ListarReporte();
            datosRep.Columns["idReporte"].Visible = false;
            //datosRep.Columns["idVehiculo"].Visible = false;
            datosRep.Columns["pagoViaticos"].Visible = false;
            datosRep.Columns["pagoExtras"].Visible = false;
            datosRep.Columns["comentario"].Visible = false;
            datosRep.Columns["idUsuario"].Visible = false;
            datosRep.Columns["nombre"].Visible = false;
        }


        
    private void btnBuscarReporte_Click(object sender, EventArgs e)
        {
            DateTime Fecha = datePickFecha.Value;
            BuscarDatos(Fecha);

            if (tbReporteBindingSource.Count == 0)
            {
                // No se encontraron reportes con la fecha especificada, muestra un mensaje
                MessageBox.Show("No se encontraron reportes con la fecha especificada.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }

        private void BuscarDatos(DateTime fecha)
        {
            datosRep.DataSource = reporte.BuscarReporte(fecha);


            if (datosRep.Rows.Count == 0)
            {
                // No se encontraron reportes con la fecha especificada, muestra un mensaje
                MessageBox.Show("No se encontraron reportes con la fecha especificada.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                datosRep.Visible = false;
                btnRegresar.Visible = true;
                //MostrarDatos();
            }
            else
            {
                datosRep.Visible = true;
            }
        }

        private void btnCrearRep_Click(object sender, EventArgs e)
        {
            frmCrearReporte frmCrearReporte = new frmCrearReporte();
            frmCrearReporte.Operacion = "Crear";
            frmCrearReporte.ShowDialog();
            MostrarDatos();
        }

        private void btnDetalles_Click(object sender, EventArgs e)
        {
            if (datosRep.SelectedRows.Count > 0)
            {
                vReporte frm = new vReporte();
                //frm.Operacion = "Editar";
                int ide = Convert.ToInt32(datosRep.CurrentRow.Cells[0].Value);
                obtenerIngresos(ide);
                frm.idReporte = ide;

                frm.txtViajes.Text = datosRep.CurrentRow.Cells["cantViajes"].Value.ToString();
                frm.txtFecha.Text = ((DateTime)datosRep.CurrentRow.Cells["Fecha"].Value).ToString("dd/MM/yyyy");
                frm.txtVehiculo.Text = datosRep.CurrentRow.Cells["Nombre"].Value.ToString();
                frm.txtTurno.Text = datosRep.CurrentRow.Cells["turno"].Value.ToString();
                frm.txtPiloto.Text = datosRep.CurrentRow.Cells["pagoPiloto"].Value.ToString();
                frm.txtAyudante.Text = datosRep.CurrentRow.Cells["pagoAyudante"].Value.ToString();
                frm.txtCombustible.Text = datosRep.CurrentRow.Cells["pagoCombustible"].Value.ToString();
                frm.txtViaticos.Text = datosRep.CurrentRow.Cells["pagoViaticos"].Value.ToString();
                frm.txtExtras.Text = datosRep.CurrentRow.Cells["pagoExtras"].Value.ToString();
                frm.txtTotalIngresos.Text = datosRep.CurrentRow.Cells["TotalIngresos"].Value.ToString();
                frm.txtTotalEgresos.Text = datosRep.CurrentRow.Cells["TotalEgresos"].Value.ToString();
                frm.txtCapital.Text = datosRep.CurrentRow.Cells["Capital"].Value.ToString();
                frm.txtComentario.Text = datosRep.CurrentRow.Cells["comentario"].Value.ToString();

                frm.ShowDialog();
                MostrarDatos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un reporte");
            }
        }

        public DataTable ListarIngresos(int ide)
        {
            DataTable dataTable = new DataTable();
            dataTable = listaIngresos.GetData(ide);
            return dataTable;
        }

        private void obtenerIngresos(int ide)
        {
            datosIng.DataSource = ListarIngresos(ide);
        }

        public void btnEditarReporte_Click(object sender, EventArgs e)
        {
            if(datosRep.SelectedRows.Count > 0)
            {
                
                frmCrearReporte frm = new frmCrearReporte();
                
                frm.Operacion = "Editar";
                int ide = Convert.ToInt32(datosRep.CurrentRow.Cells[0].Value);
                obtenerIngresos(ide);
                frm.idd = ide;
                frm.ListarVehi();
                
                frm.txtCantViajes.Text = datosRep.CurrentRow.Cells["cantViajes"].Value.ToString();
                frm.cBoxVehiculo.Text = datosRep.CurrentRow.Cells["idVehiculo"].Value.ToString();
                //frm.cBoxVehiculo.SelectedItem = datosRep.CurrentRow.Cells["idVehiculo"].Value;
                int veri = Convert.ToInt32(datosRep.CurrentRow.Cells["idVehiculo"].Value.ToString());
                
                Console.WriteLine(datosRep.CurrentRow.Cells["idVehiculo"].Value);
                //frm.cBoxVehiculo.DisplayMember = datosRep.CurrentRow.Cells["idVehiculo"].Value.ToString();
                frm.datePick.Text = datosRep.CurrentRow.Cells["Fecha"].Value.ToString();
                frm.nTurno.Text = datosRep.CurrentRow.Cells["turno"].Value.ToString();
                frm.txtPiloto.Text = datosRep.CurrentRow.Cells["pagoPiloto"].Value.ToString();
                frm.txtAyudante.Text = datosRep.CurrentRow.Cells["pagoAyudante"].Value.ToString();
                frm.txtCombustible.Text = datosRep.CurrentRow.Cells["pagoCombustible"].Value.ToString();
                frm.txtViaticos.Text = datosRep.CurrentRow.Cells["pagoViaticos"].Value.ToString();
                frm.txtExtras.Text = datosRep.CurrentRow.Cells["pagoExtras"].Value.ToString();
                frm.txtComentario.Text = datosRep.CurrentRow.Cells["comentario"].Value.ToString();

                int ca = datosIng.RowCount - 1;
                frm.crearTextBox(ca);
                frm.btnLimpiar.Visible = true;
                frm.panelViajes.Visible = true;
                frm.controlI = true;

                for (int i=0; i < ca; i++)
                {
                    
                    if (i < datosIng.Rows.Count)
                    {
                        frm.textBoxes[i].Text = datosIng.Rows[i].Cells["Ingreso"].Value.ToString();
                    }
                    else
                    {
                        // Si no hay suficientes filas en el DataTable, puedes asignar un valor predeterminado o dejar el TextBox en blanco.
                        frm.textBoxes[i].Text = "";
                    }
                }

                frm.ShowDialog();
                MostrarDatos();

            }
            else
            {
                MessageBox.Show("Debe seleccionar un reporte");
            }
        }

        private void btnEliminarReporte_Click(object sender, EventArgs e)
        {
            if (datosRep.SelectedRows.Count > 0)
            {
                
                int ide = Convert.ToInt32(datosRep.CurrentRow.Cells[0].Value);
                reporte.EliminarReporte(ide);
                MessageBox.Show("Reporte eliminado correctamente");
                MostrarDatos();
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar un reporte");
            }
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            datosRep.Visible = true;
            MostrarDatos();
            btnRegresar.Visible = false;
        }
    }
}
