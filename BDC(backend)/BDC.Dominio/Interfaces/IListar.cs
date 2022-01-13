using System.Collections.Generic;


namespace BDC.Dominio.Interfaces
{
    public interface IListar<TEntidad, TEntidadID>
    {
        List<TEntidad> Listar();
        TEntidad SeleccionarPorID(TEntidadID entidadId);



    }
}
