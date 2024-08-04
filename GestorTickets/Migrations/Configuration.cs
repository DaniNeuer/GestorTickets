// Define el espacio de nombres para las migraciones de GestorTickets.
namespace GestorTickets.Migrations
{
    // Espacio de nombres que contiene tipos fundamentales y bases de .NET.
    using System;

    // Proporciona clases y métodos para trabajar con Entity Framework.
    using System.Data.Entity;

    // Proporciona clases para realizar migraciones de la base de datos.
    using System.Data.Entity.Migrations;

    // Proporciona clases e interfaces para consultas en colecciones.
    using System.Linq;

    // Clase interna para la configuración de las migraciones.
    internal sealed class Configuration : DbMigrationsConfiguration<GestorTickets.DAL.GestorTicket>
    {
        // Constructor de la clase Configuration.
        public Configuration()
        {
            // Deshabilita las migraciones automáticas.
            AutomaticMigrationsEnabled = false;

            // Establece la clave de contexto para las migraciones.
            ContextKey = "GestorTickets.DAL.GestorTicket";
        }

        // Método para inicializar la base de datos después de migrar a la última versión.
        protected override void Seed(GestorTickets.DAL.GestorTicket context)
        {
            // Este método se llamará después de migrar a la última versión.

            // Puedes usar el método de extensión DbSet<T>.AddOrUpdate()
            // para evitar crear datos de inicialización duplicados.
        }
    }
}
