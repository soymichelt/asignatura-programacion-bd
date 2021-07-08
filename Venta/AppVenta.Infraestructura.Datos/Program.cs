using System;

using AppVenta.Infraestructura.Datos.Contextos;
namespace AppVenta.Infraestructura.Datos {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Creando la base de datos, si no existe");
			Console.WriteLine("Cargando...");

			using (VentaContexto db = new VentaContexto()) {
				db.Database.EnsureCreated();
			}

			Console.WriteLine("Procesado exitosamente!!!!!");
			Console.ReadKey();
		}
	}
}
