using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApplicationContactos.Models.DTO
{
    public class CiudadDTO
    {
        public int CiudadId { get; set; }
        public string Nombre { get; set; }
        public int ProvinciaId { get; set; }
        public int CodigoPostal { get; set; }
        public ProvinciaDTO Provincia { get; set; }
        public List<DireccionDTO> Direccion { get; set; }

        public CiudadDTO(int ciudadId, string nombre, int provinciaId, int codigoPostal, ProvinciaDTO provincia, List<DireccionDTO> direccion)
        {
            CiudadId = ciudadId;
            Nombre = nombre;
            ProvinciaId = provinciaId;
            CodigoPostal = codigoPostal;
            Provincia = provincia;
            Direccion = direccion;
        }
    }
}