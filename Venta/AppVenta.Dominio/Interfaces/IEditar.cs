using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppVenta.Dominio.Interfaces {
	public interface IEditar <TEntidad> {
		void Editar(TEntidad entidad);
	}
}
