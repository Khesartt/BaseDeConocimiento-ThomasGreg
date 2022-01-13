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
    public class NegocioClienteService : IService_linkedT<NegocioCliente, Guid>
    {
        private readonly IRepository_LinkedT<NegocioCliente, Guid> repoNegocioCliente;


        public NegocioClienteService(IRepository_LinkedT<NegocioCliente, Guid> _repoNegocioCliente)
        {
            repoNegocioCliente = _repoNegocioCliente;

        }

        public NegocioCliente Agregar(NegocioCliente x)
        {
            var resultNegocioCliente = repoNegocioCliente.Agregar(x);
            repoNegocioCliente.Guardar();
            return resultNegocioCliente;
        }

        public List<NegocioCliente> AgregarVarios(List<NegocioCliente> x)
        {
            var resultNegocioCliente = repoNegocioCliente.AgregarVarios(x);
            repoNegocioCliente.Guardar();
            return resultNegocioCliente;
        }

        public List<NegocioCliente> Listar()
        {
            return repoNegocioCliente.Listar();
        }

        public List<NegocioCliente> seleccionarOtraClave(Guid x)
        {
            return repoNegocioCliente.seleccionarOtraClave(x);
            
        }

        public List<NegocioCliente> SeleccionarPorID(Guid x)
        {
            return repoNegocioCliente.SeleccionarPorID(x);
        }
    }
}
