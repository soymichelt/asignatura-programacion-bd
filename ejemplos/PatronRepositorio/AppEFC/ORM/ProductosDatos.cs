using System;
using System.Collections.Generic;
using System.Text;
using AppEFC.ORM.Contextos;
using AppEFC.ORM.Entidades;

namespace AppEFC.ORM {
	class ProductosDatos {
		public void Agregar() {

			using (DbVenta db = new DbVenta()) {
				ProductoEntidad producto = db.Productos.Find("ID");
				producto.nombre = "COmputadora HP";


				using (DbVenta db2 = new DbVenta()) {
					db2.Productos.Remove(producto);

					db2.SaveChanges();
				}



					db.SaveChanges();
			}
		}
	}
}
