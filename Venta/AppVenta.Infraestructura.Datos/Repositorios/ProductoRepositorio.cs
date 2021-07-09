using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Dominio;
using AppVenta.Infraestructura.Datos.Contextos;

namespace AppVenta.Infraestructura.Datos.Repositorios {
	public class ProductoRepositorio : IRepositorioBase<Producto, Guid> {

		private VentaContexto db;

		public ProductoRepositorio(VentaContexto _db) {
			db = _db;
		}

		public Producto Agregar(Producto producto) {
			producto.productoId = Guid.NewGuid();

			db.Productos.Add(producto);

			return producto;
		}

		public List<Producto> Listar() {
			return db.Productos.ToList();
		}

		public void Editar(Producto producto) {
			var productoSeleccionado = db.Productos.Where(c => c.productoId == producto.productoId).FirstOrDefault();
			if (productoSeleccionado != null) {
				productoSeleccionado.nombre = producto.nombre;
				productoSeleccionado.descripcion = producto.descripcion;
				productoSeleccionado.precio = producto.precio;

				db.Entry(productoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
			}
		}

		public void Eliminar(Guid entidadId) {
			var productoSeleccionado = db.Productos.Where(c => c.productoId == entidadId).FirstOrDefault();
			if (productoSeleccionado != null) {
				db.Productos.Remove(productoSeleccionado);
			}
		}

		public Producto SeleccionarPorID(Guid entidadId) {
			var productoSeleccionado = db.Productos.Where(c => c.productoId == entidadId).FirstOrDefault();
			return productoSeleccionado;
		}

		public void GuardarTodosLosCambios() {
			db.SaveChanges();
		}
	}
}
