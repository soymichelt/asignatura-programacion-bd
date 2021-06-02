using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace biblioteca.datos.entidades {
	class LibroPrestado {
		public Guid libroPrestadoId { get; set; }

		public Guid libroId { get; set; }

		public Guid prestamoId { get; set; }

		public Prestamo prestamo { get; set; }

		public Libro libro { get; set; }
	}

	class LibroPrestadoConfig : IEntityTypeConfiguration<LibroPrestado> {
		public void Configure(EntityTypeBuilder<LibroPrestado> builder) {
			builder.ToTable("tblLibrosPrestados");
			builder.HasKey(libroPrestado => libroPrestado.libroPrestadoId);
		}
	}
}
