using GestorTickets.DAL;  // Importa el espacio de nombres para la capa de acceso a datos.
using GestorTickets.Models;  // Importa el espacio de nombres que contiene los modelos del proyecto.
using System;  // Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System.Collections.Generic;  // Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Linq;  // Proporciona clases e interfaces para consultas en colecciones.
using System.Net;  // Proporciona la clase de enumeración para el estado del protocolo HTTP.
using System.Net.Http;  // Proporciona clases para enviar solicitudes HTTP y recibir respuestas HTTP.
using System.Web.Http;  // Proporciona la clase base para un controlador API en ASP.NET.

namespace GestorTickets.Controllers  // Define el espacio de nombres para los controladores del proyecto.
{
    [RoutePrefix("api/tickets")]  // Define la ruta base para todas las acciones en este controlador.
    public class TicketController : ApiController  // Declara la clase 'TicketController' que hereda de 'ApiController'.
    {
        private GestorTicket bd = new GestorTicket();  // Crea una instancia del contexto de datos.

        [HttpPost]  // Indica que este método manejará solicitudes HTTP POST.
        [Route("agregar")]  // Define la ruta específica para esta acción.
        public IHttpActionResult AgregarTicket([FromBody] Ticket model)  // Método para agregar tickets.
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == model.UsuarioId);  // Busca el usuario en la base de datos.
            if (user == null)
            {
                return BadRequest("El usuario no existe");  // Retorna un error si el usuario no existe.
            }

            var ticket = new Ticket()
            {
                UsuarioId = model.UsuarioId,
                Cantidad = model.Cantidad
            };
            bd.Ticketes.Add(ticket);  // Agrega el ticket a la base de datos.

            bd.HistorialTickets.Add(new HistorialTicket
            {
                UsuarioId = model.UsuarioId,
                Accion = "Agregar",
                Cantidad = model.Cantidad,
                Fecha = DateTime.Now
            });
            bd.SaveChanges();  // Guarda los cambios en la base de datos.
            return Ok("Tickets agregados exitosamente");  // Retorna una respuesta exitosa.
        }

        [HttpPost]  // Indica que este método manejará solicitudes HTTP POST.
        [Route("usar")]  // Define la ruta específica para esta acción.
        public IHttpActionResult UsarTicket([FromBody] Ticket model)  // Método para usar tickets.
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == model.UsuarioId);  // Busca el usuario en la base de datos.
            if (user == null)
            {
                return BadRequest("El usuario no existe");  // Retorna un error si el usuario no existe.
            }

            var ticket = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == model.UsuarioId);  // Busca el ticket del usuario.
            if (ticket == null || ticket.Cantidad < model.Cantidad || ticket.Cantidad == 0)
            {
                return BadRequest("No hay suficientes tickets");  // Retorna un error si no hay suficientes tickets.
            }

            ticket.Cantidad -= model.Cantidad;  // Reduce la cantidad de tickets.
            bd.HistorialTickets.Add(new HistorialTicket
            {
                UsuarioId = model.UsuarioId,
                Accion = "Usar",
                Cantidad = model.Cantidad,
                Fecha = DateTime.Now
            });
            bd.SaveChanges();  // Guarda los cambios en la base de datos.
            return Ok("Tickets usados");  // Retorna una respuesta exitosa.
        }

        [HttpGet]  // Indica que este método manejará solicitudes HTTP GET.
        [Route("consultar/{usuarioId}")]  // Define la ruta específica para esta acción.
        public IHttpActionResult ConsultarTickets(int usuarioId)  // Método para consultar tickets.
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == usuarioId);  // Busca el usuario en la base de datos.
            if (user == null)
            {
                return BadRequest("El usuario no existe");  // Retorna un error si el usuario no existe.
            }

            var ticket = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == usuarioId);  // Busca el ticket del usuario.
            if (ticket == null)
            {
                return NotFound();  // Retorna un error si no se encuentra el ticket.
            }

            return Ok(ticket.Cantidad);  // Retorna la cantidad de tickets disponibles.
        }

        [HttpGet]  // Indica que este método manejará solicitudes HTTP GET.
        [Route("historial/{usuarioId}")]  // Define la ruta específica para esta acción.
        public IHttpActionResult HistorialTickets(int usuarioId)  // Método para consultar el historial de tickets.
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == usuarioId);  // Busca el usuario en la base de datos.
            if (user == null)
            {
                return BadRequest("El usuario no existe");  // Retorna un error si el usuario no existe.
            }

            var historial = bd.HistorialTickets.Where(h => h.UsuarioId == usuarioId).ToList();  // Busca el historial del usuario.
            return Ok(historial);  // Retorna el historial de tickets.
        }
    }
}
