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

        // Indica que este método manejará solicitudes HTTP POST.
        [HttpPost]

        // Define la ruta específica para esta acción.
        [Route("agregar")]

        // Método para agregar tickets.
        public IHttpActionResult AgregarTicket([FromBody] Ticket model)
        {
            // Busca el usuario en la base de datos.
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == model.UsuarioId);
            if (user == null)
            {
                // Retorna un error si el usuario no existe.
                return BadRequest("El usuario no existe");
            }

            // Crea una nueva instancia de 'Ticket' con los datos proporcionados.
            var ticket = new Ticket()
            {
                UsuarioId = model.UsuarioId,
                Cantidad = model.Cantidad
            };

            // Agrega el ticket a la base de datos.
            bd.Ticketes.Add(ticket);

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
        public IHttpActionResult UsarTicket([FromBody] Ticket model)
        {
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
        public IHttpActionResult ConsultarTickets(int usuarioId)
        {
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
        public IHttpActionResult HistorialTickets(int usuarioId)
        {
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
    }
}
