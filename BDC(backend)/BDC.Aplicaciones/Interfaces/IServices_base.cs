

using BDC.Dominio.Interfaces;

namespace BDC.Aplicaciones.Interfaces
{
    /* interfaz de servicio base para la mayoria de las entidades
     * las cuales extienden interfaces de la capa de 
     * dominio.
     */
    public interface IServices_base<TEntidad, TEntidadID> :
         IAgregar<TEntidad>,IListar<TEntidad, TEntidadID>
    {

    }
}
