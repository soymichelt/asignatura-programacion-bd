using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using AppRRHH.Aplicaciones.Interfaces;
using AppRRHH.Dominio;
using AppRRHH.Dominio.Interfaces.Repositorios;

namespace AppRRHH.Aplicaciones.Servicios {
	public class EmpleadoServicio : IServicioBase<Empleado, Guid> {

		private readonly IRepositorioBase<Empleado, Guid> repositorioEmpleado;

		public EmpleadoServicio(IRepositorioBase<Empleado, Guid> _repo) {
			repositorioEmpleado = _repo;
		}

		public Empleado Agregar(Empleado entidad) {
			if (entidad == null)
				throw new NullReferenceException("Agregar al empleado");

			return repositorioEmpleado.Agregar(entidad);
		}

		public void Editar(Empleado entidad) {
			if (entidad == null)
				throw new NullReferenceException("No se puede editar con estos datos");

			repositorioEmpleado.Editar(entidad);
		}

		public void Eliminar(Guid entidadId) {
			repositorioEmpleado.Eliminar(entidadId);
		}

		public List<Empleado> Listar() {
			var empleados = repositorioEmpleado.Listar();

			return empleados.Where(c => c.activo).ToList();
		}

		public Empleado SeleccionarPorID(Guid entidadId) {
			var empleado = repositorioEmpleado.SeleccionarPorID(entidadId);

			return empleado.activo ? empleado : null;
 		}
	}
}
