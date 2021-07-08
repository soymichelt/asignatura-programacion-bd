using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Dominio;
using AppVenta.Infraestructura.Datos.Contextos;

namespace AppVenta.Infraestructura.Datos.Repositorios {
	public class VentaRepositorio : IRepositorioMovimiento<Venta, Guid> {
		public Venta Agregar(Venta entidad) {
			using (VentaContexto db = new VentaContexto()) {
				entidad.ventaId = Guid.NewGuid();
				db.Ventas.Add(entidad);
				
				entidad.VentasDetalles.ForEach(detalle => {
					detalle.ventaId = entidad.ventaId;
					db.VentaDetalles.Add(detalle);
				});

				db.SaveChanges();

				return entidad;
			}
		}

		public void Anular(Guid entidadId) {
			using (VentaContexto db = new VentaContexto()) {
				var ventaSeleccionada = db.Ventas.Where(c => c.ventaId == entidadId && !c.anulado).FirstOrDefault();

				if (ventaSeleccionada != null) {
					ventaSeleccionada.anulado = true;

					db.Entry(ventaSeleccionada).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					db.SaveChanges();
				} else {
					throw new NullReferenceException("No se ha encontrado la venta que intenta anular... 😣");
				}
			}
		}

		public List<Venta> Listar() {
			using (VentaContexto db = new VentaContexto()) {
				return db.Ventas.ToList();
			}
		}

		public Venta SeleccionarPorID(Guid entidadId) {
			using (VentaContexto db = new VentaContexto()) {
				var ventaSeleccionada = db.Ventas.Where(c => c.ventaId == entidadId && !c.anulado).FirstOrDefault();
				ventaSeleccionada.anulado = true;

				return ventaSeleccionada;
			}
		}
	}
}
