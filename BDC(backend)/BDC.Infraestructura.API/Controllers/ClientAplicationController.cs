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
    public class ClientAplicationController : ControllerBase
    {
        ClienteAplicativoService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            ClientAplicationRepository repo = new ClientAplicationRepository(db);//crear el repositorio del producto con la conexion a bd
            ClienteAplicativoService servicio = new ClienteAplicativoService(repo);//pasa el repo al servicio 
            return servicio;

        }
        // GET: api/<BusinessClientController>
        [HttpGet("listarTablaACT")]
        public ActionResult<List<ClienteAplicacion>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoCrontoller>/5
        [HttpGet("listarTablaACT/cliente/{id}")]
        public ActionResult<ClienteAplicacion> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }
        //prueba de traer con aplicativos
        [HttpGet("listarTablaACT/aplicativo/{id}")]
        public ActionResult<ClienteAplicacion> Get2(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.seleccionarOtraClave(id));
        }
        [HttpPost("agregarTablaACT")]
        public ActionResult Post([FromBody] ClienteAplicacion clienteAplicacion)
        {
            var servicio = CrearServicio();
            servicio.Agregar(clienteAplicacion);
            return Ok("El " + clienteAplicacion + " se ha agregado satisfactoriamente.");
        }
        [HttpPost("agregarVariasTablaACT")]
        public ActionResult Post([FromBody] List<ClienteAplicacion> clienteAplicacion)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(clienteAplicacion);
            return Ok("El " + clienteAplicacion + " se ha agregado satisfactoriamente.");
        }
    }
}
