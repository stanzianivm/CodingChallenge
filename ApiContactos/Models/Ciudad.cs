using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiContactos.Models
{
    public partial class Ciudad
    {
        public Ciudad()
        {
        }

        [Key]
        public int CiudadId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public int CodigoPostal { get; set; }

        [ForeignKey(nameof(ProvinciaId))]
        public virtual Provincia Provincia { get; set; }
    }
}
