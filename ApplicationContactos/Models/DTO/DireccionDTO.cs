using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationContactos.Models.DTO
{
    public class DireccionDTO
    {
        public int DireccionId { get; set; }
        public int CiudadId { get; set; }
        [Required(ErrorMessage = "Ingresar una Calle")]
        public string Calle { get; set; }
        public string Dpto { get; set; }
        public int? Piso { get; set; }
        [Required(ErrorMessage = "Ingresar Número")]
        public int NumeroCasa { get; set; }
        public CiudadDTO Ciudad { get; set; }
        public List<ContactoDTO> Contacto { get; set; }

        public DireccionDTO() { }

        public DireccionDTO(int direccionId, int ciudadId, string calle, string dpto, int? piso, int numeroCasa, CiudadDTO ciudad, List<ContactoDTO> contacto)
        {
            DireccionId = direccionId;
            CiudadId = ciudadId;
            Calle = calle;
            Dpto = dpto;
            Piso = piso;
            NumeroCasa = numeroCasa;
            Ciudad = ciudad;
            Contacto = contacto;
        }

        public DireccionDTO(int ciudadId, string calle, string dpto, int? piso, int numeroCasa)
        {
            CiudadId = ciudadId;
            Calle = calle;
            Dpto = dpto;
            Piso = piso;
            NumeroCasa = numeroCasa;
        }
    }
}