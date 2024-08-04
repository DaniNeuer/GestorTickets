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
    [RoutePrefix("api/usuarios")]

    // Declara la clase 'UsuarioController' que hereda de 'ApiController'.
    public class UsuarioController : ApiController
    {
        // Crea una instancia del contexto de datos.
        private GestorTicket bd = new GestorTicket();

        // Indica que este método manejará solicitudes HTTP POST.
        [HttpPost]

        // Define la ruta específica para esta acción.
        [Route("crear")]

        // Método para manejar la solicitud de creación de usuario.
        public IHttpActionResult CrearUsuario([FromBody] Usuario model)
        {
            // Validar si el nombre de usuario ya existe.
            var usuarioExistente = bd.Usuarios.FirstOrDefault(u => u.NombreUsuario == model.NombreUsuario);
            if (usuarioExistente != null)
            {
                return BadRequest("El nombre de usuario ya existe.");
            }

            // Crear una nueva instancia de 'Usuario' con los datos proporcionados.
            var usuario = new Usuario
            {
                NombreUsuario = model.NombreUsuario,
                Contraseña = model.Contraseña,
                Rol = "Cliente" // Establecer el rol como "Cliente".
            };

            // Agregar el nuevo usuario a la base de datos.
            bd.Usuarios.Add(usuario);

            // Guardar los cambios en la base de datos.
            bd.SaveChanges();

            // Retornar una respuesta OK con un mensaje de éxito y el ID del usuario creado.
            return Ok(new { Message = "Usuario creado exitosamente", UsuarioId = usuario.Id });
        }
    }
}
