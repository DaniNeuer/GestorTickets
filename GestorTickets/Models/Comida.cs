using System;  // Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System.Collections.Generic;  // Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Linq;  // Proporciona clases e interfaces para consultas en colecciones.
using System.Web;  // Proporciona clases y interfaces que permiten desarrollar aplicaciones web.

namespace GestorTickets.Models  // Define el espacio de nombres del proyecto.
{
    public class Comida  // Declara la clase 'Comida'.
    {
        public int Id { get; set; }  // Propiedad 'Id' que almacena un identificador único para cada comida.
        public string Nombre { get; set; }  // Propiedad 'Nombre' que almacena el nombre de la comida.
        public decimal Precio { get; set; }  // Propiedad 'Precio' que almacena el precio de la comida.
    }
}
