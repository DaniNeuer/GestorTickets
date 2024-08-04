namespace GestorTickets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActualizarModelos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comidas", "Descripcion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comidas", "Descripcion");
        }
    }
}
