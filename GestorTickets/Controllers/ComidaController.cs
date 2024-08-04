using GestorTickets.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using GestorTickets.Models;

namespace GestorTickets.Controllers
{
    [RoutePrefix("api/comidas")]
    public class ComidaController : ApiController
    {
        private GestorTicket bd = new GestorTicket();

        private (bool IsValid, string Role) ValidateToken(string token)
        {
            // Implementar validación de token (esto es solo un ejemplo simple)
            if (token.StartsWith("token_"))
            {
                var parts = token.Split('_');
                if (parts.Length == 3)
                {
                    return (true, parts[2]);
                }
            }
            return (false, null);
        }

        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult AgregarComida([FromBody] Comida model, [FromUri] string token)
        {
            var (isValid, role) = ValidateToken(token);
            if (!isValid || role != "admin")
            {
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización para agregar comidas.");
            }

            bd.Comidas.Add(model);
            bd.SaveChanges();

            return Ok("Comida agregada exitosamente.");
        }

        [HttpPut]
        [Route("actualizar/{id}")]
        public IHttpActionResult ActualizarComida(int id, [FromBody] Comida model, [FromUri] string token)
        {
            var (isValid, role) = ValidateToken(token);
            if (!isValid || role != "admin")
            {
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización para actualizar comidas.");
            }

            var comida = bd.Comidas.FirstOrDefault(c => c.Id == id);
            if (comida == null)
            {
                return NotFound();
            }

            comida.Nombre = model.Nombre;
            comida.Descripcion = model.Descripcion;
            comida.Precio = model.Precio;
            bd.SaveChanges();

            return Ok("Comida actualizada exitosamente.");
        }

        [HttpDelete]
        [Route("eliminar/{id}")]
        public IHttpActionResult EliminarComida(int id, [FromUri] string token)
        {
            var (isValid, role) = ValidateToken(token);
            if (!isValid || role != "admin")
            {
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización para eliminar comidas.");
            }

            var comida = bd.Comidas.FirstOrDefault(c => c.Id == id);
            if (comida == null)
            {
                return NotFound();
            }

            bd.Comidas.Remove(comida);
            bd.SaveChanges();

            return Ok("Comida eliminada exitosamente.");
        }

        [HttpGet]
        [Route("listar")]
        public IHttpActionResult ListarComidas()
        {
            var comidas = bd.Comidas.ToList();
            return Ok(comidas);
        }
    }
}
