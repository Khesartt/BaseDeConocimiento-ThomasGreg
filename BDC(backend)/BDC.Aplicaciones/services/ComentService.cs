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
    public class ComentService : IServices_basic<Comentario, Guid>
    {
        private readonly IRepository_base<Comentario, Guid> repoComent;

        public ComentService(IRepository_base<Comentario, Guid> _repoComent)
        {
            repoComent = _repoComent;

        }
        public Comentario Agregar(Comentario x)
        {
            var resultComent = repoComent.Agregar(x);
            repoComent.Guardar();
            return resultComent;
        }

        public List<Comentario> AgregarVarios(List<Comentario> x)
        {
            var resultComent = repoComent.AgregarVarios(x);
            repoComent.Guardar();
            return resultComent;
        }

        public void Editar(Comentario x)
        {
            repoComent.Editar(x);
            repoComent.Guardar();
        }

        public void Eliminar(Guid x)
        {
            repoComent.Eliminar(x);
            repoComent.Guardar();
        }

        public List<Comentario> Listar()
        {
            return repoComent.Listar();
        }
   

        public Comentario SeleccionarPorID(Guid x)
        {
            return repoComent.SeleccionarPorID(x);
        }
    }
}
