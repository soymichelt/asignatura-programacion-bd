using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Dominio;
using AppVenta.Infraestructura.Datos.Contextos;

namespace AppVenta.Infraestructura.Datos.Repositorios {
	public class VentaDetalleRepositorio : IRepositorioDetalle<VentaDetalle, Guid> {

		private VentaContexto db;

		public VentaDetalleRepositorio(VentaContexto _db)
		{
			db = _db;
		}

		public VentaDetalle Agregar(VentaDetalle entidad) {
			db.VentaDetalles.Add(entidad);
			return entidad;
		}

		public void GuardarTodosLosCambios() {
			db.SaveChanges();
		}

		public List<VentaDetalle> SeleccionarDetallesPorMovimiento(Guid movimientoId) {
			return db.VentaDetalles.Where(c => c.ventaId == movimientoId).ToList();
		}
	}
}
