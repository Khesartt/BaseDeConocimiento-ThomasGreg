using System;
using System.Collections.Generic;
using System.Linq;

using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;

namespace BDC.Infraestructura.Datos.Repositories
{
   public class ClientRepository : IRepository_Binfo<Cliente, Guid>
    {
        private ApiContext db;

        public ClientRepository(ApiContext _db)
        {
            db = _db;

        }
        public Cliente Agregar(Cliente entidad)
        {
            entidad.id_cliente = Guid.NewGuid();
            db.clientes.Add(entidad);
            return entidad;
        }

        public List<Cliente> AgregarVarios(List<Cliente> entidades)
        {
            foreach (var item in entidades)
            {
                item.id_cliente = Guid.NewGuid();
                db.clientes.Add(item);
            }

            return entidades;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<Cliente> Listar()
        {
           
            return db.clientes.ToList(); 

        }

        public Cliente SeleccionarPorID(Guid entidadId)
        {
            var clienteSeleccionado = db.clientes.Where(c => c.id_cliente == entidadId).FirstOrDefault();
            return clienteSeleccionado;
        }
    }
}
