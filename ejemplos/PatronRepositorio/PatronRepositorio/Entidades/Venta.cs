using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.Entidades {
	public class Venta {
		public Guid ventaId { get; set; }
		public DateTime fecha { get; set; }
		public string Cliente { get; set; }
		public string concepto { get; set; }
		public decimal subtotal { get; set; }
		public decimal iva { get; set; }
		public decimal total { get; set; }

		public List<VentaDetalle> VentasDetalles { get; set; }
	}
}
