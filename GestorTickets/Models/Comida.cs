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
    // Declara la clase 'Comida'.
    public class Comida
    {
        // Propiedad 'Id' que almacena un identificador único para cada comida.
        public int Id { get; set; }

        // Propiedad 'Nombre' que almacena el nombre de la comida.
        public string Nombre { get; set; }

        // Propiedad 'Precio' que almacena el precio de la comida.
        public decimal Precio { get; set; }
        // Propiedad 'descripcion' que almacena una descripcion de la comida
        public string Descripcion { get; set; }
    }
}
