using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatronRepositorio.Repositorios
{
    public interface IRepositorio<Entidad, TipoIdEntidad>
    {
        Entidad Agregar(Entidad entidad);

        Entidad Editar(Entidad entidad);

        void Eliminar(TipoIdEntidad tipoId);

        Entidad Seleccionar(TipoIdEntidad tipoId);

        List<Entidad> Listado();
    }
}
