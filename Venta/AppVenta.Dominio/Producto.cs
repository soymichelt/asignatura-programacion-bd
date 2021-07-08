using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVenta.Dominio {
	public class Producto {

		public Guid productoId { get; set; }

		public string nombre { get; set; }

		public string descripcion { get; set; }

		public decimal precio { get; set; }

		public decimal cantidadEnStock { get; set; }

		public List<VentaDetalle> VentasDetalles { get; set; }

	}
}
