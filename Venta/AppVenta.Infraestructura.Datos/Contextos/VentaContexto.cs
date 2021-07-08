using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppVenta.Dominio;
using Microsoft.EntityFrameworkCore;
using AppVenta.Infraestructura.Datos.Entidades;
using AppVenta.Infraestructura.Datos.Helpers;

namespace AppVenta.Infraestructura.Datos.Contextos {
	class VentaContexto : DbContext {

		public DbSet<Producto> Productos { get; set; }

		public DbSet<Venta> Ventas { get; set; }

		public DbSet<VentaDetalle> VentaDetalles { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options) {
			options.UseSqlServer(ConfiguracionGlobal.SqlServerConnectionString);
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);

			builder.ApplyConfiguration(new ProductoConfig());
			builder.ApplyConfiguration(new VentaConfig());
			builder.ApplyConfiguration(new VentaDetalleConfig());
		}

	}
}
