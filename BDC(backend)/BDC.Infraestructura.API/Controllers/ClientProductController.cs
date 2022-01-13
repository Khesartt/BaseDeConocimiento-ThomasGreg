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
    public class ClientProductController : ControllerBase
    {
        ClienteProductoService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            ClientProductRepository repo = new ClientProductRepository(db);//crear el repositorio del producto con la conexion a bd
            ClienteProductoService servicio = new ClienteProductoService(repo);//pasa el repo al servicio 
            return servicio;

        }
        // GET: api/<BusinessClientController>
        [HttpGet("listarTablaPCT")]
        public ActionResult<List<ClienteProducto>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoCrontoller>/5
        [HttpGet("listarTablaPCT/cliente/{id}")]
        public ActionResult<ClienteProducto> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }
        //prueba de traer con aplicativos
        [HttpGet("listarTablaPCT/producto/{id}")]
        public ActionResult<ClienteProducto> Get2(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.seleccionarOtraClave(id));
        }
        [HttpPost("agregarTablaPCT")]
        public ActionResult Post([FromBody] ClienteProducto clienteProducto)
        {
            var servicio = CrearServicio();
            servicio.Agregar(clienteProducto);
            return Ok("El " + clienteProducto + " se ha agregado satisfactoriamente.");
        }
        [HttpPost("agregarVariasTablaPCT")]
        public ActionResult Post([FromBody] List<ClienteProducto> clienteProducto)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(clienteProducto);
            return Ok("El " + clienteProducto + " se ha agregado satisfactoriamente.");
        }
    }
}
