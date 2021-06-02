using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace biblioteca.datos.entidades {
	class Libro {

		public Guid libroId { get; set; }

		public string nombre { get; set; }

		public string autor { get; set; }

		public string descripcion { get; set; }

		public string editorial { get; set; }

		public List<LibroPrestado> librosPrestados { get; set; }

	}

	class LibroConfig : IEntityTypeConfiguration<Libro> {
		public void Configure(EntityTypeBuilder<Libro> builder) {
			builder.ToTable("tblLibros");
			builder.HasKey(libro => libro.libroId);
		}
	}
}
