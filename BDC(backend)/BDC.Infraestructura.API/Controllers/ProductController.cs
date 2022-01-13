using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

using BDC.Dominio;
using BDC.Aplicaciones.services;
using BDC.Infraestructura.Datos.Contexts;
using BDC.Infraestructura.Datos.Repositories;


namespace BDC.Infraestructura.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductoService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            ProductRepository repo = new ProductRepository(db);//crear el repositorio del producto con la conexion a bd
            ProductoService servicio = new ProductoService(repo);//pasa el repo al servicio 
            return servicio;

        }
        [HttpGet("listarProductos")]
        public ActionResult<List<Producto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoCrontoller>/5
        [HttpGet("listarProducto/{id}")]
        public ActionResult<Producto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        [HttpPost("agregarProducto")]
        public ActionResult Post([FromBody] Producto producto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(producto);
            return Ok("El " + producto + " se ha agregado satisfactoriamente.");
        }
        [HttpPost("agregarVariosProductos")]
        public ActionResult Post([FromBody] List<Producto> producto)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(producto);
            return Ok("El " + producto + " se ha agregado satisfactoriamente.");
        }


    }
}
