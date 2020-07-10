using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplicationASPGarage.Models
{
    public class Voiture
    {
        [Key]

        public int Numero { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Matricule { get; set; }
        public int NumeroChassis { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Marque { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Nom { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Photo { get; set; }

    }
}