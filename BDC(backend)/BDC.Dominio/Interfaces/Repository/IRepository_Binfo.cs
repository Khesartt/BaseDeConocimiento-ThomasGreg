

namespace BDC.Dominio.Interfaces.Repository
{
    /*
     * repositorio utilizado para definir las interfaces y metodos
     * que utilizaran las entidades de manera basica, siendo el traer
     * la informacion y agregarla su principal utilidad
     */
    public interface IRepository_Binfo <TEntidad, TEntidadID> 
    :IAgregar<TEntidad>,IListar<TEntidad, TEntidadID>,IGuardar
    {




    }
}
