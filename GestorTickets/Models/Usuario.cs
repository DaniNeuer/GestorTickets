using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestorTickets.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }
}