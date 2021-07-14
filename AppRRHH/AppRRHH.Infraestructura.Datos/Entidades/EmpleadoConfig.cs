using System;
using System.Collections.Generic;
using System.Text;
using AppRRHH.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppRRHH.Infraestructura.Datos.Entidades {
	class EmpleadoConfig : IEntityTypeConfiguration<Empleado> {
		public void Configure(EntityTypeBuilder<Empleado> builder) {
			builder.ToTable("tblEmpleados");
			builder.HasKey(c => c.empleadoId);
		}
	}
}
