using System;
using System.Collections.Generic;
using System.Linq;

using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;

namespace BDC.Infraestructura.Datos.Repositories
{
    public class ProductRepository : IRepository_Binfo<Producto, Guid>
    {
        private ApiContext db;

        public ProductRepository(ApiContext _db)
        {
            db = _db;

        }

        public Producto Agregar(Producto x)
        {
            x.id_producto = Guid.NewGuid();
            db.productos.Add(x);
            return x;
        }

        public List<Producto> AgregarVarios(List<Producto> entidades)
        {
            foreach (var item in entidades)
            {
                item.id_producto = Guid.NewGuid();
                db.productos.Add(item);
            }
            return entidades;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Producto> Listar()
        {
            
            return db.productos.ToList();

        }

        public Producto SeleccionarPorID(Guid entidadId)
        {
            var productoSeleccionado = db.productos.Where(c => c.id_producto == entidadId).FirstOrDefault();
            return productoSeleccionado;
        }
    }
}
