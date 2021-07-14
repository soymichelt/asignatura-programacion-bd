using System;

using AppRRHH.Infraestructura.Datos.Contextos;

namespace AppRRHH.Infraestructura.Datos {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Creando la base de datos...");
			var db = new RRHHContexto();
			db.Database.EnsureCreated();
			Console.WriteLine("Listo!!");
			Console.ReadKey();
		}
	}
}
