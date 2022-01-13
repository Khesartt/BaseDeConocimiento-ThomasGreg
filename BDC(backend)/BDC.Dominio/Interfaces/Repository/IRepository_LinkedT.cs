
using System.Collections.Generic;

namespace BDC.Dominio.Interfaces.Repository
{
    /*
     * repositorio utilizado para definir las interfaces y metodos
     * que utilizaran las tablas enlace ClienteAplicacion ClienteProducto
     * y NegocioCliente
     */ 
    public interface IRepository_LinkedT<TEntidad, TEntidadID>
       : IAgregar<TEntidad>, IGuardar
    {

        List<TEntidad> Listar();
        List<TEntidad> SeleccionarPorID(TEntidadID entidadId);
        List<TEntidad> seleccionarOtraClave(TEntidadID entidadId);
       
    }
}
