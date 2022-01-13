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
    public class ComentController : ControllerBase
    {
        ComentService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            ComentRepository repo = new ComentRepository(db);//crear el repositorio del producto con la conexion a bd
            ComentService servicio = new ComentService(repo);//pasa el repo al servicio 
            return servicio;

        }




        // GET: api/<UsuarioController>
        [HttpGet("listarTodo")]
        public ActionResult<List<Comentario>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("listarUno/{id}")]
        public ActionResult<Comentario> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<UsuarioController>
        [HttpPost("enviarComentario")]
        public ActionResult Post([FromBody] Comentario comentario)
        {
            var servicio = CrearServicio();
            servicio.Agregar(comentario);
            return Ok("datos agregados");
        }
        [HttpPost("enviarVariosComentarios")]
        public ActionResult Post([FromBody] List<Comentario> comentario)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(comentario);
            return Ok("datos agregados");
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("editarComentario/{id}")]
        public ActionResult Put(Guid id, [FromBody] Comentario comentario)
        {
            var servicio = CrearServicio();
            comentario.id_comentario = id;
            servicio.Editar(comentario);
            return Ok("El " + comentario + " se ha editado satisfactoriamente.");


        }

        // DELETE api/<UsuarioController>/5
       [HttpDelete("eliminarComentario/{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado debidamente");

        }
    }
}
