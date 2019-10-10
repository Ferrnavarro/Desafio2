using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Desafio2.Models
{
    public class Sucursal
    {
        public int Id { get; set; }

        [MaxLength(200)]
        public string Nombre { get; set; }

        [MaxLength(500)]
        public string Direccion { get; set; }

    }
}