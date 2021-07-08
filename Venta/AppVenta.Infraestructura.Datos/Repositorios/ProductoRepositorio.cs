using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Dominio;
using AppVenta.Infraestructura.Datos.Contextos;

namespace AppVenta.Infraestructura.Datos.Repositorios {
	public class ProductoRepositorio : IRepositorioBase<Producto, Guid> {
		public Producto Agregar(Producto producto) {
			producto.productoId = Guid.NewGuid();
			using (VentaContexto db = new VentaContexto()) {
				db.Productos.Add(producto);
				db.SaveChanges();
			}

			return producto;
		}

		public List<Producto> Listar() {
			using (VentaContexto db = new VentaContexto()) {
				return db.Productos.ToList();
			}
		}

		public void Editar(Producto producto) {
			using (VentaContexto db = new VentaContexto()) {
				var productoSeleccionado = db.Productos.Where(c => c.productoId == producto.productoId).FirstOrDefault();
				if (productoSeleccionado != null) {
					productoSeleccionado.nombre = producto.nombre;
					productoSeleccionado.descripcion = producto.descripcion;
					productoSeleccionado.precio = producto.precio;
					

					db.Entry(productoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
					db.SaveChanges();
				}
			}
		}

		public void Eliminar(Guid entidadId) {
			using (VentaContexto db = new VentaContexto()) {
				var productoSeleccionado = db.Productos.Where(c => c.productoId == entidadId).FirstOrDefault();
				if (productoSeleccionado != null) {
					db.Productos.Remove(productoSeleccionado);

					db.SaveChanges();
				}
			}
		}

		public Producto SeleccionarPorID(Guid entidadId) {
			using (VentaContexto db = new VentaContexto()) {
				var productoSeleccionado = db.Productos.Where(c => c.productoId == entidadId).FirstOrDefault();
				return productoSeleccionado;
			}
		}
	}
}
