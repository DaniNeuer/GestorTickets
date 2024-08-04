// Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System;

// Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Collections.Generic;

// Proporciona clases e interfaces para consultas en colecciones.
using System.Linq;

// Proporciona clases y interfaces que permiten desarrollar aplicaciones web.
using System.Web;

// Define el espacio de nombres del proyecto.
namespace GestorTickets.Models
{
    // Declara la clase 'HistorialTicket'.
    public class HistorialTicket
    {
        // Propiedad 'Id' que almacena un identificador único para cada historial de ticket.
        public int Id { get; set; }

        // Propiedad 'UsuarioId' que almacena el identificador del usuario relacionado con el historial.
        public int UsuarioId { get; set; }

        // Propiedad 'Accion' que almacena la acción realizada (e.g., agregado, reducido).
        public string Accion { get; set; }

        // Propiedad 'Cantidad' que almacena la cantidad de tickets involucrados en la acción.
        public int Cantidad { get; set; }

        // Propiedad 'Fecha' que almacena la fecha y hora en que se realizó la acción.
        public DateTime Fecha { get; set; }
    }
}
