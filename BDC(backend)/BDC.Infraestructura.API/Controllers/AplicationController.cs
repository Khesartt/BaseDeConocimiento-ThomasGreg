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
    public class AplicationController : ControllerBase
    {
        AplicationService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            AplicationRepository repo = new AplicationRepository(db);//crear el repositorio del producto con la conexion a bd
            AplicationService servicio = new AplicationService(repo);//pasa el repo al servicio 
            return servicio;

        }

        /// <summary>
        /// Obtener todos los aplicativos existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("listarAplicativos")]
        public ActionResult<List<Aplicativo>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        /// <summary>
        /// Obtener aplicacion por id
        /// </summary>
        /// <returns></returns>
        [HttpGet("listarAplicativo/{id}")]
        public ActionResult<Aplicativo> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }
        /// <summary>
        /// agregar un aplicativo a la tabla de aplicativos
        /// </summary>
        /// <param name="aplicativo"></param>
        /// <returns></returns>
        [HttpPost("agregarAplicativo")]
        public ActionResult Post([FromBody] Aplicativo aplicativo)
        {
            var servicio = CrearServicio();
            servicio.Agregar(aplicativo);
            return Ok("El " + aplicativo + " se ha agregado satisfactoriamente.");
        }
        /// <summary>
        /// agregar varios aplicativos a la tabla de aplicativos
        /// </summary>
        /// <param name="aplicativo"></param>
        /// <returns></returns>
        [HttpPost("agregarVariosAplicativos")]
        public ActionResult Post([FromBody] List<Aplicativo> aplicativo)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(aplicativo);
            return Ok("El " + aplicativo + " se ha agregado satisfactoriamente.");
        }
    }
}
