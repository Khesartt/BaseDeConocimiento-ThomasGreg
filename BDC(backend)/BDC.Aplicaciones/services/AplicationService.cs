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
    public class AplicationService : IServices_base<Aplicativo, Guid>
    {
        private readonly IRepository_Binfo<Aplicativo, Guid> repoAplication;


        public AplicationService(IRepository_Binfo<Aplicativo, Guid> _repoAplication)
        {
            repoAplication = _repoAplication;

        }

        public Aplicativo Agregar(Aplicativo x)
        {
            var resultUser = repoAplication.Agregar(x);
            repoAplication.Guardar();
            return resultUser;
        }

        public List<Aplicativo> AgregarVarios(List<Aplicativo> x)
        {
            var resultUser = repoAplication.AgregarVarios(x);
            repoAplication.Guardar();
            return resultUser;
        }

        public List<Aplicativo> Listar()
        {
            return repoAplication.Listar();
        }

        public Aplicativo SeleccionarPorID(Guid x)
        {
            return repoAplication.SeleccionarPorID(x);
        }
    }
}
