using ProjectSGR.bdSGRDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectSGR
{
    internal class Reporte
    {
        public int CantViajes {  get; set; }
        public int IdVehiculo { get; set; }
        public DateTime Fecha { get; set; }
        public int Turno { get; set; }
        public int PagoPiloto { get; set; }
        public int PagoAyudante { get; set; }
        public int PagoCombustible { get; set; }
        public int PagoViaticos { get; set; }
        public decimal PagoExtras { get; set; }
        public decimal TotalIngresos { get; set; }
        public decimal TotalEgresos { get; set; }
        public decimal Capital { get; set; }
        public string Comentario { get; set; }
        public int IdUsuario { get; set; }

        public List<decimal> Listado = new List<decimal>();

        QueriesTableAdapter adapter = new QueriesTableAdapter();

        

        //Método para crear reportes
        public void CrearReporte() 
        {
            int valorDeSalida = 1;
            byte tyn = (byte)Turno;

            // Crear un DataTable
            DataTable dataTable = new DataTable();

            DataColumn reporteColumn = new DataColumn("idReporte", typeof(int)); // Ajusta el tipo de datos según tu lista
            dataTable.Columns.Add(reporteColumn);
            // Agregar la columna "IdVuelta" con autoincremento
            DataColumn idVueltaColumn = new DataColumn("idVuelta", typeof(int));
            idVueltaColumn.AutoIncrement = true;
            idVueltaColumn.AutoIncrementSeed = 1; // Comenzar en 1
            idVueltaColumn.AutoIncrementStep = 1; // Incrementar en 1
            dataTable.Columns.Add(idVueltaColumn);

            // Agregar la columna "Ingreso" (debes ajustar el tipo de datos según la lista)
            DataColumn ingresoColumn = new DataColumn("Ingreso", typeof(decimal)); // Ajusta el tipo de datos según tu lista
            dataTable.Columns.Add(ingresoColumn);


            // Obtener una lista de ingresos (reemplaza con tu propia lista)
            List<decimal> listaIngresos = Listado; // Reemplaza esta línea con tu lista

            // Llenar el DataTable con los datos de la lista
            foreach (decimal ingreso in listaIngresos)
            {
                DataRow newRow = dataTable.NewRow();
                newRow["idReporte"] = valorDeSalida;
                newRow["Ingreso"] = ingreso; // Asigna el valor de ingreso desde la lista
                dataTable.Rows.Add(newRow);
            }

            adapter.pCrearReporte(CantViajes,IdVehiculo,Fecha,tyn,PagoPiloto,PagoAyudante,
                PagoCombustible,PagoViaticos,PagoExtras,TotalIngresos,TotalEgresos,
                Capital,Comentario,IdUsuario,dataTable);

            foreach (DataRow fila in dataTable.Rows)
            {
                // Recorre las columnas de la fila
                foreach (DataColumn columna in dataTable.Columns)
                {
                    Console.Write(fila[columna] + "\t"); // Imprime el valor de la celda
                }
                Console.WriteLine(); // Salto de línea para la siguiente fila
            }

        }

        

    }
}
