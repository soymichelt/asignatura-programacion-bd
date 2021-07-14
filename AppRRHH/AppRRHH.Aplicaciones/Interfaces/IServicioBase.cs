using System;
using System.Collections.Generic;
using System.Text;

namespace AppRRHH.Aplicaciones.Interfaces {
	interface IServicioBase<TEntidad, TEntidadID> {

		TEntidad Agregar(TEntidad entidad);

		void Editar(TEntidad entidad);

		void Eliminar(TEntidadID entidadId);

		List<TEntidad> Listar();

		TEntidad SeleccionarPorID(TEntidadID entidadId);

	}
}
