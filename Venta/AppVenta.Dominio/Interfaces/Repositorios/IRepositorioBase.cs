using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppVenta.Dominio.Interfaces;

namespace AppVenta.Dominio.Interfaces.Repositorios {
	public interface IRepositorioBase <TEntidad, TEntidadID>
		: IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID> { }
}
