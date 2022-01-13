using System;
using System.Collections.Generic;
using System.Linq;

using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;

namespace BDC.Infraestructura.Datos.Repositories
{
    public class ComentRepository : IRepository_base<Comentario, Guid>
    {
        private ApiContext db;
        public ComentRepository(ApiContext _db)
        {
            db = _db;
        }
        public Comentario Agregar(Comentario x)
        {
            x.id_comentario = Guid.NewGuid();
            db.comentarios.Add(x);
            return x;
        }

        public List<Comentario> AgregarVarios(List<Comentario> entidades)
        {
            foreach (var item in entidades)
            {
                item.id_comentario = Guid.NewGuid();
                db.comentarios.Add(item);
            }
            return entidades;
        }

        public void Editar(Comentario entidad)
        {
            var comentarioSeleccionado = db.comentarios.Where(c => c.id_comentario == entidad.id_comentario).FirstOrDefault();
            if (comentarioSeleccionado != null)
            {
                comentarioSeleccionado.id_comentario = entidad.id_comentario;
                comentarioSeleccionado.titulo = entidad.titulo;
                comentarioSeleccionado.comentarioText = entidad.comentarioText;
                comentarioSeleccionado.id_usuario = entidad.id_usuario;
                db.Entry(comentarioSeleccionado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public void Eliminar(Guid entidadId)
        {
            var comentarioSeleccionado = db.comentarios.Where(c => c.id_comentario == entidadId).FirstOrDefault();
            if (comentarioSeleccionado != null)
            {
                db.comentarios.Remove(comentarioSeleccionado);
            }
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Comentario> Listar()
        {
            return db.comentarios.ToList();
        }

        public Comentario SeleccionarPorID(Guid entidadId)
        {
            var comentarioSeleccionado = db.comentarios.Where(c => c.id_comentario == entidadId).FirstOrDefault();
            return comentarioSeleccionado;
        }
    }
}
