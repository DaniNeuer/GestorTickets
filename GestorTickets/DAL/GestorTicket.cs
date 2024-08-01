using GestorTickets.Models;  // Importa el espacio de nombres que contiene los modelos del proyecto.
using System;  // Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System.Collections.Generic;  // Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Data.Entity;  // Proporciona clases y métodos para trabajar con Entity Framework.
using System.Linq;  // Proporciona clases e interfaces para consultas en colecciones.
using System.Web;  // Proporciona clases y interfaces que permiten desarrollar aplicaciones web.

namespace GestorTickets.DAL  // Define el espacio de nombres para la capa de acceso a datos.
{
    public class GestorTicket : DbContext  // Declara la clase 'GestorTicket' que hereda de 'DbContext'.
    {
        // Define un DbSet para cada modelo que representa una tabla en la base de datos.
        public DbSet<HistorialTicket> HistorialTickets { get; set; }  // Tabla de historial de tickets.
        public DbSet<Comida> Comidas { get; set; }  // Tabla de comidas.
        public DbSet<Usuario> Usuarios { get; set; }  // Tabla de usuarios.
        public DbSet<Ticket> Ticketes { get; set; }  // Tabla de tickets.
    }
}
