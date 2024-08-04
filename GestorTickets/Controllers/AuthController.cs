// Importa el espacio de nombres para la capa de acceso a datos.
using GestorTickets.DAL;

// Importa el espacio de nombres que contiene los modelos del proyecto.
using GestorTickets.Models;

// Espacio de nombres que contiene tipos fundamentales y bases de .NET.
using System;

// Proporciona interfaces y clases genéricas para definir colecciones fuertemente tipadas.
using System.Collections.Generic;

// Proporciona clases e interfaces para consultas en colecciones.
using System.Linq;

// Proporciona la clase de enumeración para el estado del protocolo HTTP.
using System.Net;

// Proporciona clases para enviar solicitudes HTTP y recibir respuestas HTTP.
using System.Net.Http;

// Proporciona la clase base para un controlador API en ASP.NET.
using System.Web.Http;

// Define el espacio de nombres para los controladores del proyecto.
namespace GestorTickets.Controllers
{
    // Define la ruta base para todas las acciones en este controlador.
    [RoutePrefix("api/auth")]

    // Declara la clase 'AuthController' que hereda de 'ApiController'.
    public class AuthController : ApiController
    {
        // Crea una instancia del contexto de datos.
        private GestorTicket bd = new GestorTicket();

        // Indica que este método manejará solicitudes HTTP POST.
        [HttpPost]

        // Define la ruta específica para esta acción.
        [Route("login")]

        // Método para manejar la solicitud de inicio de sesión.
        public IHttpActionResult Login([FromBody] LoginModel model)
        {
            // Busca el usuario en la base de datos con el nombre de usuario y la contraseña proporcionados.
            var user = bd.Usuarios.FirstOrDefault(u => u.NombreUsuario == model.NombreUsuario && u.Contraseña == model.Contraseña);

            // Si no se encuentra el usuario, retorna un error de registro.
            if (user == null)
            {
                return BadRequest("Error usuario no registrado.");
            }

            // Si el usuario existe, genera un token para el usuario.
            var token = GenerateToken(user);

            // Retorna una respuesta OK con el token generado.
            return Ok(new { Token = token });
        }

        // Método privado para generar un token (la implementación real del token se debe agregar aquí).
        private string GenerateToken(Usuario user)
        {
            // Implementar generación de token
            return "token" + user.Id + user.Rol;  // Esto es un valor de ejemplo. Aquí se debe implementar la lógica para generar el token real.
        }
    }
}
