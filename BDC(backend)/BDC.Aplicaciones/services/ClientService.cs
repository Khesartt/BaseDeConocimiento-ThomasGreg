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
    public class ClientService : IServices_base<Cliente, Guid>
    {
        private readonly IRepository_Binfo<Cliente, Guid> repoCliente;


        public ClientService(IRepository_Binfo<Cliente, Guid> _repoCliente)
        {
            repoCliente = _repoCliente;

        }
        public Cliente Agregar(Cliente x)
        {
            var resultCliente = repoCliente.Agregar(x);
            repoCliente.Guardar();
            return resultCliente;
        }

        public List<Cliente> AgregarVarios(List<Cliente> x)
        {
            var resultCliente = repoCliente.AgregarVarios(x);
            repoCliente.Guardar();
            return resultCliente;
        }

        public List<Cliente> Listar()
        {
            return repoCliente.Listar();
        }

        public Cliente SeleccionarPorID(Guid x)
        {
            return repoCliente.SeleccionarPorID(x);
        }

        
    }
}
