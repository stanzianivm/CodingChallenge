using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiContactos.Models
{
    public partial class Direccion
    {
        public Direccion()
        {
        }

        [Key]
        public int DireccionId { get; set; }
        public int CiudadId { get; set; }
        [Required]
        [StringLength(50)]
        public string Calle { get; set; }
        [StringLength(10)]
        public string Dpto { get; set; }
        public int? Piso { get; set; }
        public int NumeroCasa { get; set; }

        [ForeignKey(nameof(CiudadId))]
        public virtual Ciudad Ciudad { get; set; }
    }
}
