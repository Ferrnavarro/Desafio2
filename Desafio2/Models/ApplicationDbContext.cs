using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Desafio2.Models
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<ItemPedido> ItemsPedido { get; set; }     
    }
}