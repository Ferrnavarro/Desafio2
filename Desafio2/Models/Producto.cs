using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Desafio2.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [MaxLength(200), Required]
        public string Nombre { get; set; }

        [MaxLength(500)]
        public string Descripcion { get; set; }


        [Range(0, int.MaxValue), Required]
        public int CantidadExistencia { get; set; }

        [Range(0.00, double.MaxValue), Required]
        public double PrecioUnitario { get; set; }
    }
}