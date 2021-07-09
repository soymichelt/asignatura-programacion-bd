using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Aplicaciones.Interfaces;
using AppVenta.Dominio;

namespace AppVenta.Aplicaciones.Servicios {
	public class VentaServicio : IServicioMovimiento<Venta, Guid> {

		private readonly IRepositorioMovimiento<Venta, Guid> repositorioVenta;
		private readonly IRepositorioBase<Producto, Guid> repositorioProducto;
		private readonly IRepositorioDetalle<VentaDetalle, Guid> repositorioDetalle;

		public VentaServicio(
			IRepositorioMovimiento<Venta, Guid> _repositorioVenta,
			IRepositorioDetalle<VentaDetalle, Guid> _repositorioDetalle,
			IRepositorioBase<Producto, Guid> _repositorioProducto
		) {
			repositorioVenta = _repositorioVenta;
			repositorioDetalle = _repositorioDetalle;
			repositorioProducto = _repositorioProducto;
		}

		public Venta Agregar(Venta entidad) {
			var ventaAgregada = repositorioVenta.Agregar(entidad);

			entidad.VentasDetalles.ForEach(detalle => {
				var productoSeleccionado = repositorioProducto.SeleccionarPorID(detalle.productoId);
				if (productoSeleccionado == null)
					throw new NullReferenceException("Usted está intentando vender un producto que no existe 😡😡😡...");

				detalle.ventaId = entidad.ventaId;
				detalle.costoVenta = productoSeleccionado.costo;
				detalle.precioVenta = productoSeleccionado.precio;
				detalle.subtotal = detalle.cantidadVendida * productoSeleccionado.precio;
				detalle.impuesto = (detalle.cantidadVendida * productoSeleccionado.precio) * 15 / 100;
				detalle.total = detalle.subtotal + detalle.impuesto;
				repositorioDetalle.Agregar(detalle);

				productoSeleccionado.cantidadEnStock -= detalle.cantidadVendida;
				repositorioProducto.Editar(productoSeleccionado);

				entidad.subtotal += detalle.subtotal;
				entidad.impuesto += detalle.impuesto;
				entidad.total += detalle.total;
			});

			repositorioVenta.GuardarTodosLosCambios();

			return ventaAgregada;
		}

		public void Anular(Guid ventaId) {
			repositorioVenta.Anular(ventaId);
			repositorioVenta.GuardarTodosLosCambios();
		}

		public List<Venta> Listar() {
			return repositorioVenta.Listar();
		}

		public Venta SeleccionarPorID(Guid ventaId) {
			return repositorioVenta.SeleccionarPorID(ventaId);
		}
	}
}
