using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AppVenta.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVenta.Infraestructura.Datos.Entidades {
	class VentaConfig : IEntityTypeConfiguration<Venta> {
		public void Configure(EntityTypeBuilder<Venta> builder) {
			builder.ToTable("tblVentas");
			builder.HasKey(venta => venta.ventaId);

			builder
				.HasMany(venta => venta.VentasDetalles)
				.WithOne(detalle => detalle.Venta);
		}
	}
}
