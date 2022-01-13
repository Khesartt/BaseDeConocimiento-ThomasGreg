using System;
using System.Collections.Generic;
using System.Linq;

using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;

namespace BDC.Infraestructura.Datos.Repositories
{
    public class bussinesRepository : IRepository_Binfo<Negocio, Guid>
    {
        private ApiContext db;

        public bussinesRepository(ApiContext _db)
        {
            db = _db;

        }

        public Negocio Agregar(Negocio x)
        {
            x.id_negocio = Guid.NewGuid();
            db.negocios.Add(x);
            return x;
        }

        public List<Negocio> AgregarVarios(List<Negocio> entidades)
        {
            foreach (var item in entidades)
            {
                item.id_negocio = Guid.NewGuid();
                db.negocios.Add(item);
            }
            return entidades;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Negocio> Listar()
        {
            return db.negocios.ToList();

        }

        public Negocio SeleccionarPorID(Guid entidadId)
        {
            var negocioSeleccionado = db.negocios.Where(c => c.id_negocio == entidadId).FirstOrDefault();
            return negocioSeleccionado;
        }
    }
}
