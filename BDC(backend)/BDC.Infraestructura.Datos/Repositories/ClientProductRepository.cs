using System;
using System.Collections.Generic;
using System.Linq;

using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;


namespace BDC.Infraestructura.Datos.Repositories
{
    public class ClientProductRepository : IRepository_LinkedT<ClienteProducto, Guid>
    {


        private ApiContext db;

        public ClientProductRepository(ApiContext _db)
        {
            db = _db;

        }

        public ClienteProducto Agregar(ClienteProducto x)
        {
            db.clienteProducto.Add(x);
            return x;
        }

        public List<ClienteProducto> AgregarVarios(List<ClienteProducto> entidades)
        {
            foreach (var item in entidades)
            {
                db.clienteProducto.Add(item);
            }
            return entidades;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<ClienteProducto> Listar()
        {
            return db.clienteProducto.ToList();
        }
        
        public List<ClienteProducto> seleccionarOtraClave(Guid entidadId)
        {

            List<ClienteProducto> datos = db.clienteProducto.ToList();
            List<ClienteProducto> aux = new List<ClienteProducto>();
            foreach (var item in datos)
            {
                if (item.id_producto.Equals(entidadId))
                {
                    aux.Add(item);
                }

            }
            return aux;
        }

        public List<ClienteProducto> SeleccionarPorID(Guid entidadId)
        {
            List<ClienteProducto> datos = db.clienteProducto.ToList();
            List<ClienteProducto> aux = new List<ClienteProducto>();
            foreach (var item in datos)
            {
                if (item.id_cliente.Equals(entidadId))
                {
                    aux.Add(item);
                }

            }
            return aux;
        }
    }



}


