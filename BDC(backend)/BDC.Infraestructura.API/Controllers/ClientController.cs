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
    public class ClientController : ControllerBase
    {
        ClientService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            ClientRepository repo = new ClientRepository(db);//crear el repositorio del producto con la conexion a bd
            ClientService servicio = new ClientService(repo);//pasa el repo al servicio 
            return servicio;

        }


        [HttpGet("listarClientes")]
        public ActionResult<List<Cliente>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<ProductoCrontoller>/5
        [HttpGet("listarCliente/{id}")]
        public ActionResult<Cliente> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }
        [HttpPost("agregarCliente")]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            var servicio = CrearServicio();
            servicio.Agregar(cliente);
            return Ok("datos enviados");
        }
        [HttpPost("agregarVariosClientes")]
        public ActionResult Post([FromBody] List<Cliente> clientes)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(clientes);
            return Ok("datos enviados");
        }

    }
}
