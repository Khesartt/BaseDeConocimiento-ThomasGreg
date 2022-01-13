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
    public class BusinessClientController : ControllerBase
    {
        NegocioClienteService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            BusinessClientRepository repo = new BusinessClientRepository(db);//crear el repositorio del producto con la conexion a bd
            NegocioClienteService servicio = new NegocioClienteService(repo);//pasa el repo al servicio 
            return servicio;

        }
        // GET: api/<BusinessClientController>
        [HttpGet("listarTablaNCT")]
        public ActionResult<List<NegocioCliente>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoCrontoller>/5
        [HttpGet("listarTablaNCT/cliente/{id}")]
        public ActionResult<NegocioCliente> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }
        [HttpGet("listarTablaNCT/negocio/{id}")]
        public ActionResult<NegocioCliente> Get2(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.seleccionarOtraClave(id));
        }
        [HttpPost("agregarTablaNCT")]
        public ActionResult Post([FromBody] NegocioCliente negocioCliente)
        {
            var servicio = CrearServicio();
            servicio.Agregar(negocioCliente);
            return Ok("El " + negocioCliente + " se ha agregado satisfactoriamente.");
        }
        [HttpPost("agregarVariasTablaNCT")]
        public ActionResult Post([FromBody] List<NegocioCliente> negocioCliente)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(negocioCliente);
            return Ok("El " + negocioCliente + " se ha agregado satisfactoriamente.");
        }
    }
}
