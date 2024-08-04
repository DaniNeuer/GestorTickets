// ************************************************************************
// Proyecto 02
// Josue Chicaiza - Daniel Tapia
// Fecha de realización: 15/07/2024
// Fecha de entrega: 05/08/2024
// ************************************************************************


// Importa el espacio de nombres que contiene los modelos del proyecto.
using GestorTickets.Models;

// Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System;

// Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Collections.Generic;

// Proporciona clases y métodos para trabajar con Entity Framework.
using System.Data.Entity;

// Proporciona clases e interfaces para consultas en colecciones.
using System.Linq;

// Proporciona clases y interfaces que permiten desarrollar aplicaciones web.
using System.Web;

// Define el espacio de nombres para la capa de acceso a datos.
namespace GestorTickets.DAL
{
    // Declara la clase 'GestorTicket' que hereda de 'DbContext'.
    public class GestorTicket : DbContext
    {
        // Define un DbSet para cada modelo que representa una tabla en la base de datos.

        // Tabla de historial de tickets.
        public DbSet<HistorialTicket> HistorialTickets { get; set; }

        // Tabla de comidas.
        public DbSet<Comida> Comidas { get; set; }

        // Tabla de usuarios.
        public DbSet<Usuario> Usuarios { get; set; }

        // Tabla de tickets.
        public DbSet<Ticket> Ticketes { get; set; }
        

    }
}
