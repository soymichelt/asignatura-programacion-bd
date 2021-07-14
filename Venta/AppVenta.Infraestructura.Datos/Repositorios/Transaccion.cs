using System;
using System.Collections.Generic;
using System.Text;

using AppVenta.Dominio.Interfaces.Repositorios;
using AppVenta.Infraestructura.Datos.Contextos;

namespace AppVenta.Infraestructura.Datos.Repositorios {
	class Transaccion {
		private VentaContexto db;

		public Transaccion() {
			db = new VentaContexto();
		}

		public void GuardarCambios() {
			db.SaveChanges();
		}

		public void ReiniciarTransaccion() {
			db = new VentaContexto();
		}
	}
}
