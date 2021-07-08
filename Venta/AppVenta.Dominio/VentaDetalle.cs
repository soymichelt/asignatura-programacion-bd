using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVenta.Dominio {
	public class VentaDetalle {

		public Guid productoId { get; set; }

		public Guid ventaId { get; set; }

		public decimal cantidadVendida { get; set; }

		public decimal costoVenta { get; set; }

		public decimal precioVenta { get; set; }

		public decimal subtotal { get; set; }

		public decimal descuento { get; set; }

		public decimal impuesto { get; set; }

		public decimal total { get; set; }

		public Producto Producto { get; set; }

		public Venta Venta { get; set; }

	}
}
