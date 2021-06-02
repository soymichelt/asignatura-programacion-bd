using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace biblioteca.datos.entidades {
	class Prestamo {
		public Guid prestamoId { get; set; }

		public DateTime fecha { get; set; }

		public DateTime fechaVencimiento { get; set; }

		public string visitante { get; set; }

		public string concepto { get; set; }

		public List<LibroPrestado> librosPrestados { get; set; }
	}

	class PrestamoConfig : IEntityTypeConfiguration<Prestamo> {
		public void Configure(EntityTypeBuilder<Prestamo> builder) {
			builder.ToTable("tblPrestamos");
			builder.HasKey(prestamo => prestamo.prestamoId);
		}
	}
}
