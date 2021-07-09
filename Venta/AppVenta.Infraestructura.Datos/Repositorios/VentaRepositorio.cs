using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Dominio;
using AppVenta.Infraestructura.Datos.Contextos;

namespace AppVenta.Infraestructura.Datos.Repositorios {
	public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid> {

		private VentaContexto db;

		public VentaRepositorio(VentaContexto _db) {
			db = _db;
		}

		public Venta Agregar(Venta entidad) {
			entidad.ventaId = Guid.NewGuid();
			db.Ventas.Add(entidad);
			return entidad;
		}

		public void Anular(Guid entidadId) {
			var ventaSeleccionada = SeleccionarPorID(entidadId);

			if (ventaSeleccionada != null) {
				ventaSeleccionada.anulado = true;

				db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			} else {
				throw new NullReferenceException("No se ha encontrado la venta que intenta anular... 😣");
			}
		}

		public void GuardarTodosLosCambios() {
			db.SaveChanges();
		}

		public List<Venta> Listar() {
			return db.Ventas.ToList();
		}

		public Venta SeleccionarPorID(Guid entidadId) {
			var ventaSeleccionada = db.Ventas.Where(c => c.ventaId == entidadId && !c.anulado).FirstOrDefault();
			return ventaSeleccionada;
		}
	}
}
