using System;
using System.Collections.Generic;
using System.Linq;


using BDC.Dominio.Interfaces.Repository;
using BDC.Dominio;
using BDC.Infraestructura.Datos.Contexts;
namespace BDC.Infraestructura.Datos.Repositories
{
    public class BusinessClientRepository : IRepository_LinkedT<NegocioCliente, Guid>
    {
        private ApiContext db;

        public BusinessClientRepository(ApiContext _db)
        {
            db = _db;

        }

        public NegocioCliente Agregar(NegocioCliente x)
        {
            db.negocioCliente.Add(x);
            return x;
        }

        public List<NegocioCliente> AgregarVarios(List<NegocioCliente> entidades)
        {
            foreach (var item in entidades)
            {
                db.negocioCliente.Add(item);
            }
            return entidades;
        }

        public void Guardar()
        {
            db.SaveChanges();
        }

        public List<NegocioCliente> Listar()
        {

            return db.negocioCliente.ToList();

        }

        public List<NegocioCliente> seleccionarOtraClave(Guid entidadId)
        {
            List<NegocioCliente> datos = db.negocioCliente.ToList();
            List<NegocioCliente> aux = new List<NegocioCliente>();
            foreach (var item in datos)
            {
                if (item.id_negocio.Equals(entidadId))
                {
                    aux.Add(item);
                }

            }
            return aux;
        }

        public List<NegocioCliente> SeleccionarPorID(Guid entidadId)
        {
            List<NegocioCliente> datos = db.negocioCliente.ToList();
            List<NegocioCliente> aux = new List<NegocioCliente>();
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
