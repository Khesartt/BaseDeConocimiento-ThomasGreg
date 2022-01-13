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
    public class UserService : IServices_basic<Usuario, Guid>
    {
        private readonly IRepository_base<Usuario, Guid> repoUser;

        
        public UserService(IRepository_base<Usuario, Guid> _repoUser)
        {
            repoUser = _repoUser;
        }
        
        public Usuario Agregar(Usuario x)
        {
            var resultUser = repoUser.Agregar(x);
            repoUser.Guardar();
            return resultUser;
        }

        public List<Usuario> AgregarVarios(List<Usuario> x)
        {
            var resultUsers = repoUser.AgregarVarios(x);
            repoUser.Guardar();
            return resultUsers;
        }

        public void Editar(Usuario x)
        {
            repoUser.Editar(x);
            repoUser.Guardar();
        }

        public void Eliminar(Guid xId)
        {
            repoUser.Eliminar(xId);
            repoUser.Guardar();
        }

        public List<Usuario> Listar()
        {
            return repoUser.Listar();
        }

        public Usuario SeleccionarPorID(Guid xId)
        {
            return repoUser.SeleccionarPorID(xId);
        }
    }
}
