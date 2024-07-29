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

    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        private GestorTicket bd = new GestorTicket();

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] LoginModel model)
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.NombreUsuario == model.NombreUsuario && u.Contraseña == model.Contraseña);
            if (user == null)
            {
                return BadRequest("Error usuario no registrado.");
            }
            var token = GenerateToken(user);
            return Ok(new { Token = token });
        }

        private string GenerateToken(Usuario user)
        {
            // Implementar generación de token
            return "token";
        }
    }
}
