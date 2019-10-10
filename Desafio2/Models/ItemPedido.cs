using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Desafio2.Models
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProductoId { get; set; }
        public Producto Producto { get; set; }

        [Range(0, int.MaxValue)]
        public int Cantidad { get; set; }

    }
}