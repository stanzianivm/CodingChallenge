using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationContactos.Models.DTO
{
    public class ProvinciaDTO
    {
        public int ProvinciaId { get; set; }
        public string Nombre { get; set; }
        public List<CiudadDTO> Ciudad { get; set; }

        public ProvinciaDTO(int provinciaId, string nombre, List<CiudadDTO> ciudad)
        {
            ProvinciaId = provinciaId;
            Nombre = nombre;
            Ciudad = ciudad;
        }
    }
}