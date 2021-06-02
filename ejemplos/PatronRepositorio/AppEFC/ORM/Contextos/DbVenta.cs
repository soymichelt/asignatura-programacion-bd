using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AppEFC.ORM.Entidades;

namespace AppEFC.ORM.Contextos {
	class DbVenta : DbContext {
		public DbSet<ProductoEntidad> Productos { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
			optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB; Initial Catalog=OtraDb; Integrated Security=true;");
		}

		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new ProductoConfiguracion());
		}
	}
}
