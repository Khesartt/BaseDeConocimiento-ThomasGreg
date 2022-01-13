using System;
using System.Collections.Generic;
using System.Linq;

using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;


namespace BDC.Infraestructura.Datos.Repositories
{
    public class UserRepository : IRepository_base<Usuario, Guid>
    {
        private ApiContext db;
        public UserRepository(ApiContext _db)
        {
            db = _db;
        }

        public Usuario Agregar(Usuario x)
        {
            x.id_usuario = Guid.NewGuid();
            db.Usuarios.Add(x);
            return x;
        }

        public List<Usuario> AgregarVarios(List<Usuario> entidades)
        {

            foreach (var item in entidades)
            {
                item.id_usuario = Guid.NewGuid();
                db.Usuarios.Add(item);
            }
            return entidades;
        }

        public void Editar(Usuario entidad)
        {
            var UsuarioSeleccionado = db.Usuarios.Where(c => c.id_usuario == entidad.id_usuario).FirstOrDefault();
            if (UsuarioSeleccionado != null)
            {
                UsuarioSeleccionado.id_usuario = entidad.id_usuario;
                UsuarioSeleccionado.nombres = entidad.nombres;
                UsuarioSeleccionado.apellidos = entidad.apellidos;
                UsuarioSeleccionado.usuario = entidad.usuario;
                UsuarioSeleccionado.contraseña = entidad.contraseña;
                UsuarioSeleccionado.correo = entidad.correo;
                UsuarioSeleccionado.rol = entidad.rol;
                UsuarioSeleccionado.activo = entidad.activo;

                db.Entry(UsuarioSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var UsuarioSeleccionado = db.Usuarios.Where(c => c.id_usuario == entidadId).FirstOrDefault();
            if (UsuarioSeleccionado != null)
            {
                db.Usuarios.Remove(UsuarioSeleccionado);
            }
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return db.Usuarios.ToList();
        }

        public Usuario SeleccionarPorID(Guid entidadId)
        {
            var UsuarioSeleccionado = db.Usuarios.Where(c => c.id_usuario == entidadId).FirstOrDefault();
            return UsuarioSeleccionado;
        }
    }
}
