using System;
using System.Collections.Generic;

using BDC.Dominio;
using BDC.Dominio.Interfaces.Repository;
using BDC.Aplicaciones.Interfaces;



namespace BDC.Aplicaciones.services
{
    /* extiendo de una interfaz que determina que metodos debo seguir
     * para esta entidad.
     */
    public class ProductoService : IServices_base<Producto, Guid>
    {
        private readonly IRepository_Binfo<Producto, Guid> repoProducto;

        
        public ProductoService(IRepository_Binfo<Producto, Guid> _repoProducto)
        {
            repoProducto = _repoProducto;

        }

        public Producto Agregar(Producto x)
        {
            var resultproduct = repoProducto.Agregar(x);
            repoProducto.Guardar();
            return resultproduct;
        }

        public List<Producto> AgregarVarios(List<Producto> x)
        {
            var resultproduct = repoProducto.AgregarVarios(x);
            repoProducto.Guardar();
            return resultproduct;
        }

        public List<Producto> Listar()
        {
            return repoProducto.Listar();
        }

        public Producto SeleccionarPorID(Guid x)
        {
            return repoProducto.SeleccionarPorID(x);
        }
    }
}
