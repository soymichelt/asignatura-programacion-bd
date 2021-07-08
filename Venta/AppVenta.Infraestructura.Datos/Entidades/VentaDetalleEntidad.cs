using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AppVenta.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVenta.Infraestructura.Datos.Entidades {

	class VentaDetalleConfig : IEntityTypeConfiguration<VentaDetalle> {
		public void Configure(EntityTypeBuilder<VentaDetalle> builder) {
			builder.ToTable("tblVentasDetalles");

			builder.HasKey(detalle => new { detalle.productoId, detalle.ventaId });

			builder
				.HasOne(detalle => detalle.Producto)
				.WithMany(producto => producto.VentasDetalles);

			builder
				.HasOne(detalle => detalle.Venta)
				.WithMany(venta => venta.VentasDetalles);
		}
	}
}
