using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using AppRRHH.Dominio;
using AppRRHH.Infraestructura.Datos.Entidades;

namespace AppRRHH.Infraestructura.Datos.Contextos {
	class RRHHContexto : DbContext {

		public DbSet<Empleado> Empleados { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder op) {
			op.UseSqlServer(@"Data source=(localdb)\MSSQLLocalDB; Initial Catalog=misEmpleados; Integrated Security = true;");
		}
		protected override void OnModelCreating(ModelBuilder builder) {
			base.OnModelCreating(builder);
			builder.ApplyConfiguration(new EmpleadoConfig());
		}
	}
}
