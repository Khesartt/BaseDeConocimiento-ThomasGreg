using System;
using System.Collections.Generic;
using System.Linq;

using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;


namespace BDC.Infraestructura.Datos.Repositories
{
    public class CodeRepository : IRepository_Binfo<Codigo, Guid>
    {
        private ApiContext db;

        public CodeRepository(ApiContext _db)
        {
            db = _db;

        }

        public Codigo SeleccionarPorID(Guid entidadId)
        {
            var codigoSeleccionado = db.codigos
                .Where(c => c.id_codigo == entidadId)
                .FirstOrDefault();
            return codigoSeleccionado;
        }






        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Codigo> Listar()
        {
            return db.codigos.ToList();

        }

       


        public Codigo Agregar(Codigo x)
        {
            x.id_codigo = Guid.NewGuid();
            db.codigos.Add(x);
            return x;
        }

        public List<Codigo> AgregarVarios(List<Codigo> entidades)
        {
            foreach (var item in entidades)
            {
                item.id_codigo = Guid.NewGuid();
                db.codigos.Add(item);
            }
            return entidades;
        }

       
    }
}
