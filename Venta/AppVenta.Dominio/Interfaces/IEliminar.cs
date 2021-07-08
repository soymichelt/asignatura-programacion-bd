using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Interfaces {
	public interface IEliminar<TEntidadID> {
		void Eliminar(TEntidadID entidadId);
	}
}
