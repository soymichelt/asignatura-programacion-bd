using System;
using biblioteca.datos.contextos;

namespace biblioteca {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Creando base de datos si no existe...");
			BibliotecaDb db = new BibliotecaDb();
			db.Database.EnsureCreated();
			Console.WriteLine("Base de datos lista!!!!!!");

			Console.ReadKey();
		}
	}
}
