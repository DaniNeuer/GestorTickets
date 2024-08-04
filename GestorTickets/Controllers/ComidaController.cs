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
    // Define el prefijo de la ruta para todos los métodos en este controlador
    [RoutePrefix("api/comidas")]
    public class ComidaController : ApiController
    {
        // Crea una instancia de GestorTicket para interactuar con la base de datos
        private GestorTicket bd = new GestorTicket();

        // Método privado para validar el token
        private (bool IsValid, string Role) ValidateToken(string token)
        {
            // Implementar validación de token (esto es solo un ejemplo simple)
            if (token.StartsWith("token_"))
            {
                // Divide el token en partes usando el carácter '_'
                var parts = token.Split('_');
                // Verifica si el token tiene exactamente 3 partes
                if (parts.Length == 3)
                {
                    // Devuelve true y la tercera parte del token como el rol del usuario
                    return (true, parts[2]);
                }
            }
            // Si el token no es válido, devuelve false y null
            return (false, null);
        }

        // Método HTTP POST para agregar una nueva comida
        [HttpPost]
        // Define la ruta para este método
        [Route("agregar")]
        public IHttpActionResult AgregarComida([FromBody] Comida model, [FromUri] string token)
        {
            // Valida el token
            var (isValid, role) = ValidateToken(token);
            // Verifica si el token no es válido o si el rol no es "admin"
            if (!isValid || role != "admin")
            {
                // Devuelve un mensaje de error de autorización
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización para agregar comidas.");
            }

            // Agrega la nueva comida a la base de datos
            bd.Comidas.Add(model);
            // Guarda los cambios en la base de datos
            bd.SaveChanges();

            // Devuelve un mensaje de éxito
            return Ok("Comida agregada exitosamente.");
        }

        // Método HTTP PUT para actualizar una comida existente
        [HttpPut]
        // Define la ruta para este método con un parámetro id
        [Route("actualizar/{id}")]
        public IHttpActionResult ActualizarComida(int id, [FromBody] Comida model, [FromUri] string token)
        {
            // Valida el token
            var (isValid, role) = ValidateToken(token);
            // Verifica si el token no es válido o si el rol no es "admin"
            if (!isValid || role != "admin")
            {
                // Devuelve un mensaje de error de autorización
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización para actualizar comidas.");
            }

            // Busca la comida por id en la base de datos
            var comida = bd.Comidas.FirstOrDefault(c => c.Id == id);
            // Verifica si no se encontró la comida
            if (comida == null)
            {
                // Devuelve un mensaje de error de "No encontrado"
                return NotFound();
            }

            // Actualiza los datos de la comida
            comida.Nombre = model.Nombre;
            comida.Descripcion = model.Descripcion;
            comida.Precio = model.Precio;
            // Guarda los cambios en la base de datos
            bd.SaveChanges();

            // Devuelve un mensaje de éxito
            return Ok("Comida actualizada exitosamente.");
        }

        // Método HTTP DELETE para eliminar una comida existente
        [HttpDelete]
        // Define la ruta para este método con un parámetro id
        [Route("eliminar/{id}")]
        public IHttpActionResult EliminarComida(int id, [FromUri] string token)
        {
            // Valida el token
            var (isValid, role) = ValidateToken(token);
            // Verifica si el token no es válido o si el rol no es "admin"
            if (!isValid || role != "admin")
            {
                // Devuelve un mensaje de error de autorización
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización para eliminar comidas.");
            }

            // Busca la comida por id en la base de datos
            var comida = bd.Comidas.FirstOrDefault(c => c.Id == id);
            // Verifica si no se encontró la comida
            if (comida == null)
            {
                // Devuelve un mensaje de error de "No encontrado"
                return NotFound();
            }

            // Elimina la comida de la base de datos
            bd.Comidas.Remove(comida);
            // Guarda los cambios en la base de datos
            bd.SaveChanges();

            // Devuelve un mensaje de éxito
            return Ok("Comida eliminada exitosamente.");
        }

        // Método HTTP GET para listar todas las comidas
        [HttpGet]
        // Define la ruta para este método
        [Route("listar")]
        public IHttpActionResult ListarComidas()
        {
            // Obtiene la lista de todas las comidas de la base de datos
            var comidas = bd.Comidas.ToList();
            // Devuelve la lista de comidas
            return Ok(comidas);
        }
    }
}
