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
    // Declara la clase 'Usuario'.
    public class Usuario
    {
        // Propiedad 'Id' que almacena un identificador único para cada usuario.
        public int Id { get; set; }

        // Propiedad 'NombreUsuario' que almacena el nombre de usuario.
        public string NombreUsuario { get; set; }

        // Propiedad 'Contraseña' que almacena la contraseña del usuario.
        public string Contraseña { get; set; }

        // Propiedad 'Rol' que almacena el rol del usuario (e.g., administrador, cliente).
        public string Rol { get; set; }
    }
}
