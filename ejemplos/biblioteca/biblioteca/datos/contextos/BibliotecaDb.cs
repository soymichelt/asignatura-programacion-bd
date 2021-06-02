using System;
using System.Collections.Generic;
using System.Text;
using biblioteca.datos.entidades;
using Microsoft.EntityFrameworkCore;

namespace biblioteca.datos.contextos {
	class BibliotecaDb : DbContext {

		public DbSet<Prestamo> prestamos { get; set; }

		public DbSet<Libro> libros { get; set; }

		public DbSet<LibroPrestado> librosPrestados { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog = bibliotecaDb; Integrated Security = true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfiguration(new PrestamoConfig());
			modelBuilder.ApplyConfiguration(new LibroConfig());
			modelBuilder.ApplyConfiguration(new LibroPrestadoConfig());
		}

	}
}
