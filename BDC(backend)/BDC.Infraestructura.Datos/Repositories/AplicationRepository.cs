using System;
using System.Collections.Generic;
using System.Linq;

using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;


namespace BDC.Infraestructura.Datos.Repositories
{
    public class AplicationRepository : IRepository_Binfo<Aplicativo, Guid>
    {
        private ApiContext db;

        public AplicationRepository(ApiContext _db)
        {
            db = _db;

        }

        public Aplicativo Agregar(Aplicativo x)
        {
            x.id_aplicativo = Guid.NewGuid();
            db.aplicativos.Add(x);
            return x;
        }

        public List<Aplicativo> AgregarVarios(List<Aplicativo> entidades)
        {
            foreach (var item in entidades)
            {
                item.id_aplicativo = Guid.NewGuid();
                db.aplicativos.Add(item);
            }
            return entidades;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Aplicativo> Listar()
        {
            return db.aplicativos.ToList();
        }

        public Aplicativo SeleccionarPorID(Guid entidadId)
        {
            var aplicativoSeleccionado = db.aplicativos.Where(c => c.id_aplicativo == entidadId).FirstOrDefault();
            return aplicativoSeleccionado;
        }


    }
}
