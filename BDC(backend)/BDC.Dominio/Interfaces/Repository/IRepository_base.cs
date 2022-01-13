



namespace BDC.Dominio.Interfaces.Repository
{
    /*
     * repositorio con un CRUD basico para las entidades
     */
    public interface IRepository_base<TEntidad, TEntidadID> 
    : IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>, IGuardar
    {
    }
}
