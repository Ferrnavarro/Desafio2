namespace Desafio2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cambio_precio : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productoes", "Precio", c => c.Double(nullable: false));
            DropColumn("dbo.Productoes", "PrecioUnitario");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "PrecioUnitario", c => c.Double(nullable: false));
            DropColumn("dbo.Productoes", "Precio");
        }
    }
}
