using System;
using System.Collections.Generic;

using BDC.Dominio;
using BDC.Dominio.Interfaces.Repository;
using BDC.Aplicaciones.Interfaces;

namespace BDC.Aplicaciones.services
{
    /* extiendo de una interfaz que determina que metodos debo seguir
     * para esta entidad.
     */
    public class ClienteAplicativoService : IService_linkedT<ClienteAplicacion, Guid>
    {
        private readonly IRepository_LinkedT<ClienteAplicacion, Guid> repoClienteAplicacion;


        public ClienteAplicativoService(IRepository_LinkedT<ClienteAplicacion, Guid> _repoClienteAplicacion)
        {
            repoClienteAplicacion = _repoClienteAplicacion;

        }
        public ClienteAplicacion Agregar(ClienteAplicacion x)
        {
            var resultClienteAplicacion = repoClienteAplicacion.Agregar(x);
            repoClienteAplicacion.Guardar();
            return resultClienteAplicacion;
        }
        public List<ClienteAplicacion> AgregarVarios(List<ClienteAplicacion> x)
        {
            var resultClienteAplicacion = repoClienteAplicacion.AgregarVarios(x);
            repoClienteAplicacion.Guardar();
            return resultClienteAplicacion;
        }

        public List<ClienteAplicacion> Listar()
        {
            return repoClienteAplicacion.Listar();
        }

        public List<ClienteAplicacion> seleccionarOtraClave(Guid x)
        {
            return repoClienteAplicacion.seleccionarOtraClave(x);
        }

        public List<ClienteAplicacion> SeleccionarPorID(Guid x)
        {
            return repoClienteAplicacion.SeleccionarPorID(x);
        }
    }
}
