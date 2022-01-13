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
    public class BusinessController : ControllerBase
    {

        BusinessService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            bussinesRepository repo = new bussinesRepository(db);//crear el repositorio del producto con la conexion a bd
            BusinessService servicio = new BusinessService(repo);//pasa el repo al servicio 
            return servicio;

        }

        /// <summary>
        /// Obtener todos los negocios existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet("listarNegocios")]
        public ActionResult<List<Negocio>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        /// <summary>
        /// Obtener negocio por id
        /// </summary>
        /// <returns></returns>
        [HttpGet("listarNegocio/{id}")]
        public ActionResult<Negocio> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }
        /// <summary>
        /// agregar un negocios a la tabla de negocios
        /// </summary>
        /// <param name="negocio"></param>
        /// <returns></returns>
        [HttpPost("agregarNegocio")]
        public ActionResult Post([FromBody] Negocio negocio)
        {
            var servicio = CrearServicio();
            servicio.Agregar(negocio);
            return Ok("El " + negocio + " se ha agregado satisfactoriamente.");
        }
        /// <summary>
        /// agregar varios negocios a la tabla de negocios
        /// </summary>
        /// <param name="negocio"></param>
        /// <returns></returns>
        [HttpPost("agregarVariosNegocios")]
        public ActionResult Post([FromBody] List<Negocio> negocio)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(negocio);
            return Ok("El " + negocio + " se ha agregado satisfactoriamente.");
        }
    }
}
