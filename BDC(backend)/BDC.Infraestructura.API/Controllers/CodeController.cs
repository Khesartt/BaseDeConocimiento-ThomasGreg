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
    public class CodeController : ControllerBase
    {
        CodeService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            CodeRepository repo = new CodeRepository(db);//crear el repositorio del codigo con la conexion a bd
            CodeService servicio = new CodeService(repo);//pasa el repo al servicio 
            return servicio;
        }
        /*
         * localhost:44319/api/code/listarcodigos
         */
        [HttpGet("listarCodigos")]
        public ActionResult<List<Codigo>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }
        /*
         * localhost:44319/api/code/listarcodigo/{id}
         */
        [HttpGet("listarCodigo/{id}")]
        public ActionResult<Codigo> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }




        [HttpPost("agregarCodigo")]
        public ActionResult Post([FromBody] Codigo codigo)
        {
            var servicio = CrearServicio();
            servicio.Agregar(codigo);
            return Ok("El " + codigo + " se ha agregado satisfactoriamente.");
        }
        [HttpPost("agregarVariosCodigos")]
        public ActionResult Post([FromBody] List<Codigo> codigo)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(codigo);
            return Ok("El " + codigo + " se ha agregado satisfactoriamente.");
        }
    }
}
