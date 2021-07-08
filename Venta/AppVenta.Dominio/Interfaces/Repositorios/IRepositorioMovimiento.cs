using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppVenta.Dominio.Interfaces;

namespace AppVenta.Dominio.Interfaces.Repositorios {
	public interface IRepositorioMovimiento<TEntidad, TEntidadID>
		: IAgregar<TEntidad>, IListar<TEntidad, TEntidadID> {

		void Anular(TEntidadID entidadId);

	}
}
