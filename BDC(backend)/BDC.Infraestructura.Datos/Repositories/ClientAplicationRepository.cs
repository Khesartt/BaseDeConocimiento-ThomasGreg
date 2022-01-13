using System;
using System.Collections.Generic;
using System.Linq;

using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;

namespace BDC.Infraestructura.Datos.Repositories
{
   public class ClientAplicationRepository : IRepository_LinkedT<ClienteAplicacion, Guid>
    {
        private ApiContext db;

        public ClientAplicationRepository(ApiContext _db)
        {
            db = _db;

        }
        public ClienteAplicacion Agregar(ClienteAplicacion x)
        {
            db.clienteAplicacion.Add(x);
            return x;
        }
        public List<ClienteAplicacion> AgregarVarios(List<ClienteAplicacion> entidades)
        {
            foreach (var item in entidades)
            {
                db.clienteAplicacion.Add(item);
            }
            return entidades;
        }
        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<ClienteAplicacion> Listar()
        {

            return db.clienteAplicacion.ToList();

        }

        public List<ClienteAplicacion> SeleccionarPorID(Guid entidadId)
        {
            List<ClienteAplicacion> datos = db.clienteAplicacion.ToList();
            List<ClienteAplicacion> aux = new List<ClienteAplicacion>();
            foreach (var item in datos)
            {
                if (item.id_cliente.Equals(entidadId))
                {
                    aux.Add(item);
                }

            }
            return aux;
        }
        public List<ClienteAplicacion> seleccionarOtraClave(Guid entidadId)
        {
            List<ClienteAplicacion> datos = db.clienteAplicacion.ToList();
            List<ClienteAplicacion> aux = new List<ClienteAplicacion>();
            foreach (var item in datos)
            {
                if (item.id_aplicativo.Equals(entidadId))
                {
                    aux.Add(item);
                }

            }
            return aux;
        }
       

    }
}
