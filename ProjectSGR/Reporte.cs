using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSGR
{
    internal class Reporte
    {
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

    }
}
