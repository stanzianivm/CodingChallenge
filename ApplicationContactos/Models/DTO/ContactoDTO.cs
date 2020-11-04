using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ApplicationContactos.Models.DTO
{
    public class ContactoDTO
    {
        public int ContactoId { get; set; }
        [Required(ErrorMessage = "Ingresar un Nombre")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Ingresar una Empresa")]
        public string Empresa { get; set; }
        [Required(ErrorMessage = "Ingresar un Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Formato Incorrecto")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ingresar Fecha de Nacimiento")]
        public string FechaNacimiento { get; set; }
        [Required(ErrorMessage = "Ingresar un Teléfono")]
        public string Telefono { get; set; }
        public int DireccionId { get; set; }
        public string ImagenPerfil { get; set; }
        public DireccionDTO Direccion { get; set; }

        public ContactoDTO()
        {
        }

        public ContactoDTO(int contactoId, string nombre, string empresa, string email, string fechaNacimiento, string telefono, int direccionId, string imagenPerfil, DireccionDTO direccion)
        {
            ContactoId = contactoId;
            Nombre = nombre;
            Empresa = empresa;
            Email = email;
            FechaNacimiento = fechaNacimiento;
            Telefono = telefono;
            DireccionId = direccionId;
            ImagenPerfil = imagenPerfil;
            Direccion = direccion;
        }

    }
}