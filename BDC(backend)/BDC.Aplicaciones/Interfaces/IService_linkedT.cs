using BDC.Dominio.Interfaces;
using System.Collections.Generic;

namespace BDC.Aplicaciones.Interfaces
{
    /* interfaz final para el servicio de las tablas enlace 
     * extiende de la interfaz agregar de la capa de dominio
     * y agrega metodos propios.
     */
   public interface IService_linkedT<TEntidad, TEntidadID>
         : IAgregar<TEntidad>
    {
        List<TEntidad> Listar();
        List<TEntidad> SeleccionarPorID(TEntidadID entidadId);
        List<TEntidad> seleccionarOtraClave(TEntidadID entidadId);

    }
}
