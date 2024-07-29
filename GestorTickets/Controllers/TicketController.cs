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
    [RoutePrefix("api/tickets")]
    public class TicketController : ApiController
    {
        private GestorTicket bd = new GestorTicket();

        [HttpPost]
        [Route("agregar")]
        public IHttpActionResult AgregarTicket([FromBody] Ticket model)
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == model.UsuarioId);
            if(user == null)
            {
                return BadRequest("El usuario no existe");
            }
            var ticket = new Ticket()
            {
                UsuarioId = model.UsuarioId,
                Cantidad = model.Cantidad
            };
            bd.Ticketes.Add(ticket);
            bd.HistorialTickets.Add(new HistorialTicket
            {
                UsuarioId = model.UsuarioId,
                Accion = "Agregar",
                Cantidad = model.Cantidad,
                Fecha = DateTime.Now
            });
            bd.SaveChanges();
            return Ok("Tickets agregados exitosamente");
        }
        [HttpPost]
        [Route("usar")]
        public IHttpActionResult UsarTicket([FromBody] Ticket model)
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == model.UsuarioId);
            if(user == null)
            {
                return BadRequest("El usuario no existe");
            }
            var ticket = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == model.UsuarioId);
            if (ticket == null || ticket.Cantidad < model.Cantidad || ticket.Cantidad == 0)
            {
                return BadRequest("no hay suficientes tickets");
            }
            ticket.Cantidad -= model.Cantidad;
            bd.HistorialTickets.Add(new HistorialTicket
            {
                UsuarioId = model.UsuarioId,
                Accion = "Usar",
                Cantidad = model.Cantidad,
                Fecha = DateTime.Now
            });
            bd.SaveChanges();
            return Ok("Tickets usados");
        }
        [HttpGet]
        [Route("consultar/{usuarioId}")]
        public IHttpActionResult ConsultarTickets(int usuarioId)
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (user == null)
            {
                return BadRequest("El usuario no existe");
            }
            var ticket = bd.Ticketes.FirstOrDefault(t => t.UsuarioId == usuarioId);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket.Cantidad);
        }

        [HttpGet]
        [Route("historial/{usuarioId}")]
        public IHttpActionResult HistorialTickets(int usuarioId)
        {
            var user = bd.Usuarios.FirstOrDefault(u => u.Id == usuarioId);
            if (user == null)
            {
                return BadRequest("El usuario no existe");
            }
            var historial = bd.HistorialTickets.Where(h => h.UsuarioId == usuarioId).ToList();
            return Ok(historial);
        }
    }
}
