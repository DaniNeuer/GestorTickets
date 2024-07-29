using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorTickets.Models
{
    public class HistorialTicket
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Accion { get; set; }
        public int Cantidad { get; set; }
        public DateTime Fecha { get; set; }
    }
}