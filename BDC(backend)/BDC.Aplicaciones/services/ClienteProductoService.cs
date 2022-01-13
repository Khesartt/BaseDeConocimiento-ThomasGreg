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
    public class ClienteProductoService : IService_linkedT<ClienteProducto, Guid>
    {
        private readonly IRepository_LinkedT<ClienteProducto, Guid> repoClienteProducto;


        public ClienteProductoService(IRepository_LinkedT<ClienteProducto, Guid> _repoClienteProducto)
        {
            repoClienteProducto = _repoClienteProducto;

        }

        public ClienteProducto Agregar(ClienteProducto x)
        {
            var resultClienteProducto = repoClienteProducto.Agregar(x);
            repoClienteProducto.Guardar();
            return resultClienteProducto;
        }

        public List<ClienteProducto> AgregarVarios(List<ClienteProducto> x)
        {
            var resultClienteProducto = repoClienteProducto.AgregarVarios(x);
            repoClienteProducto.Guardar();
            return resultClienteProducto;
        }

        public List<ClienteProducto> Listar()
        {
            return repoClienteProducto.Listar();
        }

        public List<ClienteProducto> seleccionarOtraClave(Guid x)
        {
            return repoClienteProducto.seleccionarOtraClave(x);

        }

        public List<ClienteProducto> SeleccionarPorID(Guid x)
        {
            return repoClienteProducto.SeleccionarPorID(x);
        }
    }
}
