namespace Desafio2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombres = c.String(nullable: false, maxLength: 200),
                        Apellidos = c.String(nullable: false, maxLength: 200),
                        Direccion = c.String(maxLength: 500),
                        Telefono = c.String(),
                        Email = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemPedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PedidoId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pedidoes", t => t.PedidoId, cascadeDelete: true)
                .ForeignKey("dbo.Productoes", t => t.ProductoId, cascadeDelete: true)
                .Index(t => t.PedidoId)
                .Index(t => t.ProductoId);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                        SucursalId = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clientes", t => t.ClienteId, cascadeDelete: true)
                .ForeignKey("dbo.Sucursals", t => t.SucursalId, cascadeDelete: true)
                .Index(t => t.ClienteId)
                .Index(t => t.SucursalId);
            
            CreateTable(
                "dbo.Sucursals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 200),
                        Direccion = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 200),
                        Descripcion = c.String(maxLength: 500),
                        CantidadExistencia = c.Int(nullable: false),
                        PrecioUnitario = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedidoes", "ProductoId", "dbo.Productoes");
            DropForeignKey("dbo.ItemPedidoes", "PedidoId", "dbo.Pedidoes");
            DropForeignKey("dbo.Pedidoes", "SucursalId", "dbo.Sucursals");
            DropForeignKey("dbo.Pedidoes", "ClienteId", "dbo.Clientes");
            DropIndex("dbo.Pedidoes", new[] { "SucursalId" });
            DropIndex("dbo.Pedidoes", new[] { "ClienteId" });
            DropIndex("dbo.ItemPedidoes", new[] { "ProductoId" });
            DropIndex("dbo.ItemPedidoes", new[] { "PedidoId" });
            DropTable("dbo.Productoes");
            DropTable("dbo.Sucursals");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.ItemPedidoes");
            DropTable("dbo.Clientes");
        }
    }
}
