using System;
using AppEFC.ORM.Contextos;

namespace AppEFC {
	class Program {
		static void Main(string[] args) {
			Console.WriteLine("Creando la base de datos...");
			var db = new DbVenta();
			db.Database.EnsureCreated();
			Console.WriteLine("Genial, se creo la db!!!");
			Console.ReadKey();
		}
	}
}
