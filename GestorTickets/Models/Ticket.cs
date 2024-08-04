// Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System;

// Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Collections.Generic;

// Proporciona clases e interfaces para consultas en colecciones.
using System.Linq;

// Proporciona clases e interfaces que permiten desarrollar aplicaciones web.
using System.Web;

// Define el espacio de nombres del proyecto.
namespace GestorTickets.Models
{
    // Declara la clase 'Ticket'.
    public class Ticket
    {
        // Propiedad 'Id' que almacena un identificador único para cada ticket.
        public int Id { get; set; }

        // Propiedad 'UsuarioId' que almacena el identificador del usuario al que pertenece el ticket.
        public int UsuarioId { get; set; }

        // Propiedad 'Cantidad' que almacena la cantidad de tickets.
        public int Cantidad { get; set; }
    }
}
