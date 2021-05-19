using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.Repositorios {
	public interface IListar<Entidad, TipoEntidadId> {
		Entidad Seleccionar(TipoEntidadId entidadId);

		List<Entidad> Listar();
	}
}
