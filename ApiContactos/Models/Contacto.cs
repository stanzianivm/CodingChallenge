using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiContactos.Models
{
    public partial class Contacto
    {
        [Key]
        public int ContactoId { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Empresa { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string FechaNacimiento { get; set; }
        [Required]
        [StringLength(50)]
        public string Telefono { get; set; }
        public int DireccionId { get; set; }
        [StringLength(50)]
        public string ImagenPerfil { get; set; }

        [ForeignKey(nameof(DireccionId))]
        public virtual Direccion Direccion { get; set; }
    }
}
