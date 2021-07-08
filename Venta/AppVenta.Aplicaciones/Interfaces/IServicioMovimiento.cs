using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AppVenta.Dominio.Interfaces;
using AppVenta.Dominio;


namespace AppVenta.Aplicaciones.Interfaces {
	public interface IServicioMovimiento<TEntidad, TEntidadID> : IAgregar<TEntidad>, IListar<TEntidad, TEntidadID> {
		void Anular(TEntidadID entidadId);
	}
}
