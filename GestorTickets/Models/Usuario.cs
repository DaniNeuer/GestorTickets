using System;  // Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System.Collections.Generic;  // Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Linq;  // Proporciona clases e interfaces para consultas en colecciones.
using System.Web;  // Proporciona clases y interfaces que permiten desarrollar aplicaciones web.

namespace GestorTickets.Models  // Define el espacio de nombres del proyecto.
{
    public class Usuario  // Declara la clase 'Usuario'.
    {
        public int Id { get; set; }  // Propiedad 'Id' que almacena un identificador único para cada usuario.
        public string NombreUsuario { get; set; }  // Propiedad 'NombreUsuario' que almacena el nombre de usuario.
        public string Contraseña { get; set; }  // Propiedad 'Contraseña' que almacena la contraseña del usuario.
        public string Rol { get; set; }  // Propiedad 'Rol' que almacena el rol del usuario (e.g., administrador, cliente).
    }
}
