using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiContactos.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
        }

        [Key]
        public int ProvinciaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
    }
}
