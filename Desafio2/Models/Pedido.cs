using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Desafio2.Models
{
    public class Pedido
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public int SucursalId { get; set; }

        public Sucursal Sucursal { get; set; }

        public DateTime Fecha { get; set; }

        public IEnumerable<ItemPedido> Items { get; set; }


    }
}