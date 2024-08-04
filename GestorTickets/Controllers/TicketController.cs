// Importa el espacio de nombres para la capa de acceso a datos.
using GestorTickets.DAL;

// Importa el espacio de nombres que contiene los modelos del proyecto.
using GestorTickets.Models;

// Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System;

// Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Collections.Generic;

// Proporciona clases e interfaces para consultas en colecciones.
using System.Linq;

// Proporciona la clase de enumeración para el estado del protocolo HTTP.
using System.Net;

// Proporciona clases para enviar solicitudes HTTP y recibir respuestas HTTP.
using System.Net.Http;

// Proporciona la clase base para un controlador API en ASP.NET.
using System.Web.Http;

// Define el espacio de nombres para los controladores del proyecto.
namespace GestorTickets.Controllers
{
    // Define la ruta base para todas las acciones en este controlador.
    [RoutePrefix("api/tickets")]

    // Declara la clase 'TicketController' que hereda de 'ApiController'.
    public class TicketController : ApiController
    {
        // Crea una instancia del contexto de datos.
        private GestorTicket bd = new GestorTicket();


        //Funcion para validar el token y extrar el rol del usuario 
        private (bool IsValid, string Role) ValidateToken(string token)
        {
            // Implementar validación de token 
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

        // Indica que este método manejará solicitudes HTTP POST.
        [HttpPost]

        // Define la ruta específica para esta acción.
        [Route("agregar")]

        // Método para agregar tickets.
        public IHttpActionResult AgregarTicket([FromBody] Ticket model, [FromUri] string token)
        {
            var (isValid, role) = ValidateToken(token);
            if(!isValid || role != "admin")
            {
                return Unauthorized();
            }
            // Busca el usuario en la base de datos.
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == model.UsuarioId);
            if (user == null)
            {
                // Retorna un error si el usuario no existe.
                return BadRequest("El usuario no existe");
            }

            // Busca el registro de tickets existente para el usuario.
            var ticket = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == model.UsuarioId);
            if (ticket != null)
            {
                // Incrementa la cantidad de tickets existentes.
                ticket.Cantidad += model.Cantidad;
            }
            else
            {
                // Crea una nueva instancia de 'Ticket' si no existe un registro previo.
                ticket = new Ticket
                {
                    UsuarioId = model.UsuarioId,
                    Cantidad = model.Cantidad
                };


                bd.Ticketes.Add(ticket);
            }

            // Agrega una nueva entrada al historial de tickets.
            bd.HistorialTickets.Add(new HistorialTicket
            {
                UsuarioId = model.UsuarioId,
                Accion = "Agregar",
                Cantidad = model.Cantidad,
                Fecha = DateTime.Now
            });

            // Guarda los cambios en la base de datos.
            bd.SaveChanges();

            // Retorna una respuesta exitosa.
            return Ok("Tickets agregados exitosamente");
        }

        // Indica que este método manejará solicitudes HTTP POST.
        [HttpPost]

        // Define la ruta específica para esta acción.
        [Route("usar")]

        // Método para usar tickets.
        public IHttpActionResult UsarTicket([FromBody] Ticket model, [FromUri] string token)
        {
            var (isValid, role) = ValidateToken(token);
            if (!isValid || role != "admin")
            {
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización para reducir tickets."); 
            }
            // Busca el usuario en la base de datos.
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == model.UsuarioId);
            if (user == null)
            {
                // Retorna un error si el usuario no existe.
                return BadRequest("El usuario no existe");
            }

            // Busca el ticket del usuario.
            var ticket = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == model.UsuarioId);
            if (ticket == null || ticket.Cantidad < model.Cantidad || ticket.Cantidad == 0)
            {
                // Retorna un error si no hay suficientes tickets.
                return BadRequest("No hay suficientes tickets");
            }

            // Reduce la cantidad de tickets.
            ticket.Cantidad -= model.Cantidad;

            // Agrega una nueva entrada al historial de tickets.
            bd.HistorialTickets.Add(new HistorialTicket
            {
                UsuarioId = model.UsuarioId,
                Accion = "Usar",
                Cantidad = model.Cantidad,
                Fecha = DateTime.Now
            });

            // Guarda los cambios en la base de datos.
            bd.SaveChanges();

            // Retorna una respuesta exitosa.
            return Ok("Tickets usados");
        }

        // Indica que este método manejará solicitudes HTTP GET.
        [HttpGet]

        // Define la ruta específica para esta acción.
        [Route("consultar/{usuarioId}")]

        // Método para consultar tickets.
        public IHttpActionResult ConsultarTickets(int usuarioId, [FromUri] string token)
        {
            var (isValid, role) = ValidateToken(token);
            if (!isValid || role != "Cliente")
            {
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización para consultar la cantidad de tickets.");
            }
            // Busca el usuario en la base de datos.
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (user == null)
            {
                // Retorna un error si el usuario no existe.
                return BadRequest("El usuario no existe");
            }

            // Busca el ticket del usuario.
            var ticket = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == usuarioId);
            if (ticket == null)
            {
                // Retorna un error si no se encuentra el ticket.
                return NotFound();
            }

            // Retorna la cantidad de tickets disponibles.
            return Ok(ticket.Cantidad);
        }

        // Indica que este método manejará solicitudes HTTP GET.
        [HttpGet]

        // Define la ruta específica para esta acción.
        [Route("historial/{usuarioId}")]

        // Método para consultar el historial de tickets.
        public IHttpActionResult HistorialTickets(int usuarioId, [FromUri] string token)
        {
            var (isValid, role) = ValidateToken(token);
            if (!isValid || role != "Cliente")
            {
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización observar el historial de tickets.");
            }
            // Busca el usuario en la base de datos.
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (user == null)
            {
                // Retorna un error si el usuario no existe.
                return BadRequest("El usuario no existe");
            }

            // Busca el historial del usuario.
            var historial = bd.HistorialTickets.Where(h => h.UsuarioId == usuarioId).ToList();

            // Retorna el historial de tickets.
            return Ok(historial);
        }

        // Método para pagar comida por parte de Cliente
        [HttpPost]
        [Route("pagar")]
        public IHttpActionResult PagarComida([FromBody] Ticket model, [FromUri] string token)
        {
            var (isValid, role) = ValidateToken(token);
            if (!isValid || role != "Cliente")
            {
                return Content(HttpStatusCode.Unauthorized, "No tienes autorización para pagar una comida.");
            }

            var usuario = bd.Usuarios.FirstOrDefault(u => u.Id == model.UsuarioId);
            if (usuario == null)
            {
                return BadRequest("El usuario no existe.");
            }

            var ticket = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == model.UsuarioId);
            if (ticket == null || ticket.Cantidad < 1)
            {
                return BadRequest("No hay suficientes tickets.");
            }
            // Reducir el número de tickets restantes en 1
            ticket.Cantidad -= 1; 
            bd.HistorialTickets.Add(new HistorialTicket
            {
                UsuarioId = model.UsuarioId,
                Accion = "Pagar",
                Cantidad = 1,
                Fecha = DateTime.Now
            });
            bd.SaveChanges();

            return Ok(new { Message = "Pago realizado con éxito", TicketsRestantes = ticket.Cantidad });
        }
    }
}
