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
    public class BusinessService : IServices_base<Negocio, Guid>
    {
        private readonly IRepository_Binfo<Negocio, Guid> repoNegocio;


        public BusinessService(IRepository_Binfo<Negocio, Guid> _repoNegocio)
        {
            repoNegocio = _repoNegocio;

        }

        public Negocio Agregar(Negocio x)
        {
            var resultNegocio = repoNegocio.Agregar(x);
            repoNegocio.Guardar();
            return resultNegocio;
        }

        public List<Negocio> AgregarVarios(List<Negocio> x)
        {
            var resultNegocio = repoNegocio.AgregarVarios(x);
            repoNegocio.Guardar();
            return resultNegocio;
        }

        public List<Negocio> Listar()
        {
            return repoNegocio.Listar();
        }

        public Negocio SeleccionarPorID(Guid x)
        {
            return repoNegocio.SeleccionarPorID(x);
        }
    }
}
