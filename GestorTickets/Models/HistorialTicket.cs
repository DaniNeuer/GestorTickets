using System;  // Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System.Collections.Generic;  // Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Linq;  // Proporciona clases e interfaces para consultas en colecciones.
using System.Web;  // Proporciona clases y interfaces que permiten desarrollar aplicaciones web.

namespace GestorTickets.Models  // Define el espacio de nombres del proyecto.
{
    public class HistorialTicket  // Declara la clase 'HistorialTicket'.
    {
        public int Id { get; set; }  // Propiedad 'Id' que almacena un identificador único para cada historial de ticket.
        public int UsuarioId { get; set; }  // Propiedad 'UsuarioId' que almacena el identificador del usuario relacionado con el historial.
        public string Accion { get; set; }  // Propiedad 'Accion' que almacena la acción realizada (e.g., agregado, reducido).
        public int Cantidad { get; set; }  // Propiedad 'Cantidad' que almacena la cantidad de tickets involucrados en la acción.
        public DateTime Fecha { get; set; }  // Propiedad 'Fecha' que almacena la fecha y hora en que se realizó la acción.
    }
}
