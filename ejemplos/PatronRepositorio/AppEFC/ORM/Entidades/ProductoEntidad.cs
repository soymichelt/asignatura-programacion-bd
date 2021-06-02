using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppEFC.ORM.Entidades {

	class ProductoEntidad {
		public Guid productoId { get; set; }
		public string nombre { get; set; }
		public string descripcion { get; set; }
		public decimal stock { get; set; }
		public decimal precio { get; set; }
		public decimal costo { get; set; }
	}

	class ProductoConfiguracion : IEntityTypeConfiguration<ProductoEntidad> {
		public void Configure(EntityTypeBuilder<ProductoEntidad> builder) {
			builder.ToTable("tblProductos");
			builder.HasKey(entidad => entidad.productoId);
		}
	}

}
