using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Desafio2.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        [MaxLength(200), Required]
        public string Nombres { get; set; }

        [MaxLength(200), Required]
        public string Apellidos { get; set; }

        [MaxLength(500)]
        public string Direccion { get; set; }

        [Phone]
        public string Telefono { get; set; }

        [EmailAddress]
        public string Email { get; set; }


        [Display(Name = "Fecha Nacimiento")]          
        public DateTime FechaNacimiento { get; set; }


    }
}