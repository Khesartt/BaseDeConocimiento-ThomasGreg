

using System.Collections.Generic;

namespace BDC.Dominio.Interfaces
{
    public interface IAgregar<TEntidad>
    {
        TEntidad Agregar(TEntidad entidad);

        List<TEntidad> AgregarVarios(List<TEntidad> entidades);
    }
}
