using GestorTickets.DAL;
using GestorTickets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace GestorTickets.Controllers
{
    [RoutePrefix("api/usuarios")]
    public class UsuarioController : ApiController
    {
        private GestorTicket bd = new GestorTicket();

        [HttpPost]
        [Route("crear")]
        public IHttpActionResult CrearUsuario([FromBody] Usuario model)
        {
            // Validar si el nombre de usuario ya existe
            var usuarioExistente = bd.Usuarios.FirstOrDefault(u => u.NombreUsuario == model.NombreUsuario);
            if (usuarioExistente != null)
            {
                return BadRequest("El nombre de usuario ya existe.");
            }

            var usuario = new Usuario
            {
                NombreUsuario = model.NombreUsuario,
                Contraseña = model.Contraseña,
                Rol = "Cliente" // Establecer el rol como "Cliente"
            };

            bd.Usuarios.Add(usuario);
            bd.SaveChanges();

            return Ok(new { Message = "Usuario creado exitosamente", UsuarioId = usuario.Id });
        }

    }
}
