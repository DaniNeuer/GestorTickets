using System;  // Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System.Collections.Generic;  // Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Linq;  // Proporciona clases e interfaces para consultas en colecciones.
using System.Web;  // Proporciona clases y interfaces que permiten desarrollar aplicaciones web.

namespace GestorTickets.Models  // Define el espacio de nombres del proyecto.
{
    public class LoginModel  // Declara la clase 'LoginModel'.
    {
        public string NombreUsuario { get; set; }  // Propiedad 'NombreUsuario' que almacena el nombre de usuario para el login.
        public string Contraseña { get; set; }  // Propiedad 'Contraseña' que almacena la contraseña para el login.
    }
}
