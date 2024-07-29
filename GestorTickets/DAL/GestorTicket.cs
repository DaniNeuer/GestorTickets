using GestorTickets.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace GestorTickets.DAL
{
    public class GestorTicket : DbContext
    {
        public DbSet<HistorialTicket> HistorialTickets { get; set; }
        public DbSet<Comida> Comidas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Ticket> Ticketes { get; set; }
    }
}