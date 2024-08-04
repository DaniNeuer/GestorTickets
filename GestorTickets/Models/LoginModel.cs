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
    // Declara la clase 'LoginModel'.
    public class LoginModel
    {
        // Propiedad 'NombreUsuario' que almacena el nombre de usuario para el login.
        public string NombreUsuario { get; set; }

        // Propiedad 'Contraseña' que almacena la contraseña para el login.
        public string Contraseña { get; set; }
    }
}
