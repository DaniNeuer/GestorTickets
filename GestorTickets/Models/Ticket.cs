using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorTickets.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int Cantidad { get; set; }
    }
}