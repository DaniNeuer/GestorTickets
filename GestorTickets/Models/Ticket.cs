using System;  // Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System.Collections.Generic;  // Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Linq;  // Proporciona clases e interfaces para consultas en colecciones.
using System.Web;  // Proporciona clases y interfaces que permiten desarrollar aplicaciones web.

namespace GestorTickets.Models  // Define el espacio de nombres del proyecto.
{
    public class Ticket  // Declara la clase 'Ticket'.
    {
        public int Id { get; set; }  // Propiedad 'Id' que almacena un identificador único para cada ticket.
        public int UsuarioId { get; set; }  // Propiedad 'UsuarioId' que almacena el identificador del usuario al que pertenece el ticket.
        public int Cantidad { get; set; }  // Propiedad 'Cantidad' que almacena la cantidad de tickets.
    }
}
