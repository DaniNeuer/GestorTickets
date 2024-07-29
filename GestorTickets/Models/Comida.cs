using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorTickets.Models
{
    public class Comida
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
    }
}