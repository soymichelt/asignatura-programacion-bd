using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Aplicaciones.Interfaces;
using AppVenta.Dominio;

namespace AppVenta.Aplicaciones.Servicios {
	public class VentaServicio : IServicioMovimiento<Venta, Guid> {

		private readonly IRepositorioMovimiento<Venta, Guid> repositorio;

		public VentaServicio(IRepositorioMovimiento<Venta, Guid> _repositorio) {
			repositorio = _repositorio;
		}

		public Venta Agregar(Venta entidad) {
			return repositorio.Agregar(entidad);
		}

		public void Anular(Guid ventaId) {
			repositorio.Anular(ventaId);
		}

		public List<Venta> Listar() {
			return repositorio.Listar();
		}

		public Venta SeleccionarPorID(Guid ventaId) {
			return repositorio.SeleccionarPorID(ventaId);
		}
	}
}
