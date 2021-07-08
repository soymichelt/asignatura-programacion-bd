using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using AppVenta.Dominio;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppVenta.Infraestructura.Datos.Entidades {

	class ProductoConfig : IEntityTypeConfiguration<Producto> {

		public void Configure(EntityTypeBuilder<Producto> builder) {

			builder.ToTable("tblProductos");

			builder.HasKey(producto => producto.productoId);

			builder
				.HasMany(producto => producto.VentasDetalles)
				.WithOne(detalle => detalle.Producto);

		}

	}
}
