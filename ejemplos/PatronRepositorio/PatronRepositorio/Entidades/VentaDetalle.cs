using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.Entidades {
	public class VentaDetalle {

		public Guid productoId { get; set; }
		public Guid ventaId { get; set; }
		public decimal cantidadVendido { get; set; }
		public decimal precioProducto { get; set; }
		public decimal total { get; set; }

	}
}
