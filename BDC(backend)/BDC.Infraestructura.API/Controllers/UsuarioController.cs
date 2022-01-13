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
    public class UsuarioController : ControllerBase
    {

       UserService CrearServicio()
        {
            ApiContext db = new ApiContext(); //crea una conexion a la base de datos establecia en el contexto
            UserRepository repo = new UserRepository(db);//crear el repositorio del producto con la conexion a bd
            UserService servicio = new UserService(repo);//pasa el repo al servicio 
            return servicio;

        }




        // GET: api/<UsuarioController>
        [HttpGet("listarTodo")]
        public ActionResult<List<Usuario>> Get()
        {
            var servicio = CrearServicio();
            return Ok(servicio.Listar());
        }

        // GET api/<UsuarioController>/5
        [HttpGet("listarUno/{id}")]
        public ActionResult<Usuario> Get(Guid id)
        {
            var servicio = CrearServicio();
            return Ok(servicio.SeleccionarPorID(id));
        }

        // POST api/<UsuarioController>
        [HttpPost("enviarUsuario")]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            var servicio = CrearServicio();
            servicio.Agregar(usuario);
            return Ok("datos agregados");
        }
        [HttpPost("enviarVariosUsuarios")]
        public ActionResult Post([FromBody] List<Usuario> usuario)
        {
            var servicio = CrearServicio();
            servicio.AgregarVarios(usuario);
            return Ok("datos agregados");
        }

        // PUT api/<UsuarioController>/5
        [HttpPut("editarUsuario/{id}")]
        public ActionResult Put(Guid id, [FromBody] Usuario usuario)
        {
            var servicio = CrearServicio();
            usuario.id_usuario = id;
            servicio.Editar(usuario);
            return Ok("El " + usuario + " se ha editado satisfactoriamente.");


        }

        // DELETE api/<UsuarioController>/5
        [HttpDelete("eliminarUsuario/{id}")]
        public ActionResult Delete(Guid id)
        {
            var servicio = CrearServicio();
            servicio.Eliminar(id);
            return Ok("Eliminado debidamente");

        }
    }
}
