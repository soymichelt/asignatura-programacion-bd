using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using AppRRHH.Dominio;
using AppRRHH.Dominio.Interfaces.Repositorios;
using AppRRHH.Infraestructura.Datos.Contextos;

namespace AppRRHH.Infraestructura.Datos.Repositorios {
	public class EmpleadoRepositorio : IRepositorioBase<Empleado, Guid> {
		public Empleado Agregar(Empleado entidad) {
			using (var db = new RRHHContexto()) {
				entidad.empleadoId = Guid.NewGuid();
				db.Empleados.Add(entidad);
				db.SaveChanges();
			}
			return entidad;
		}

		public void Editar(Empleado entidad) {
			using (var db = new RRHHContexto()) {
				var empleadoSeleccionado = db.Empleados.Find(entidad.empleadoId);
				if (empleadoSeleccionado != null) {
					empleadoSeleccionado.nombres = entidad.nombres;
					empleadoSeleccionado.apellidos = entidad.apellidos;
					empleadoSeleccionado.area = entidad.area;
					empleadoSeleccionado.salario = entidad.salario;
					empleadoSeleccionado.activo = entidad.activo;

					db.Entry(empleadoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

					db.SaveChanges();
				}
			}
		}

		public void Eliminar(Guid entidadId) {
			using (var db = new RRHHContexto()) {
				var empleadoSeleccionado = db.Empleados.Find(entidadId);
				if (empleadoSeleccionado != null) {
					empleadoSeleccionado.activo = false;

					db.Entry(empleadoSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

					db.SaveChanges();
				}
			}
		}

		public List<Empleado> Listar() {
			using (var db = new RRHHContexto()) {
				return db.Empleados.ToList();
			}
		}

		public Empleado SeleccionarPorID(Guid entidadId) {
			using (var db = new RRHHContexto()) {
				var empleadoSeleccionado = db.Empleados.Find(entidadId);
				return empleadoSeleccionado;
			}
		}
	}
}
