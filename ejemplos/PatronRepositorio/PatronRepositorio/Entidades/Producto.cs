using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.Entidades {
	public class Producto {
		public Guid productoId { get; set; }
		public string nombre { get; set; }
		public string descripcion { get; set; }
		public decimal cantidad { get; set; }
		public decimal precio { get; set; }
	}
}
