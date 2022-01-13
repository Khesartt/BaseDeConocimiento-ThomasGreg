using BDC.Dominio.Interfaces;

namespace BDC.Aplicaciones.Interfaces
{
    /* interfaz final de un servicio basico para una entidad
     * contiene las interfaces basicas de un CRUD heredadas 
     * de la capa de dominio
     */
    public interface IServices_basic<TEntidad, TEntidadID> :
       IAgregar<TEntidad>, IEditar<TEntidad>, IEliminar<TEntidadID>, IListar<TEntidad, TEntidadID>
    {

    }
}
