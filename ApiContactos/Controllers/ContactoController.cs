using ApiContactos.Models;
using ApiContactos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContactos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactoController : ControllerBase
    {
        private readonly ContactosContext _context;

        public ContactoController(ContactosContext context)
        {
            _context = context;
        }

        //api/Contacto?telefono=123456&email=juan@algo.com&provinciaId=2&ciudadId=3
        [HttpGet]
        public ActionResult<IEnumerable<Contacto>> GetAllByFilter([FromQuery]string telefono, [FromQuery]string email, [FromQuery]string provinciaId, [FromQuery]string ciudadId)
        {
            var contacto = new ContactoService(_context).GetAllByFilter(telefono, email, provinciaId, ciudadId);

            if (contacto == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }

            return contacto;
        }

        //api/Contacto/14
        [HttpGet("{id}")]
        public ActionResult<Contacto> GetById(int id)
        {
            var contacto = new ContactoService(_context).GetById(id);

            if (contacto == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }

            return contacto;
        }

        //api/Contacto?13
        [HttpPut]
        public IActionResult PutContacto(Contacto contacto)
        {
            try
            {
                // Verifico si el contacto existe ->
                var result = new ContactoService(_context).GetById(contacto.ContactoId);

                // Si es false retorno una exception ->
                if (result == null)
                    throw new Exception("El usuario no existe");

                // Realizo la modificación del contacto ->
                new ContactoService(_context).Modified(contacto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }

            return NoContent();
        }

        //api/Contacto
        [HttpPost]
        public ActionResult<Contacto> PostUsuario(Contacto contacto)
        {
            new ContactoService(_context).Add(contacto);

            return CreatedAtAction("GetById", new { id = contacto.ContactoId }, contacto);
        }

        //api/Contacto?13
        [HttpDelete("{id}")]
        public IActionResult DeleteUsuario(int id)
        {
            try
            {
                // Obtengo el contacto a eliminar ->
                var contacto = new ContactoService(_context).GetById(id);

                // Si el contacto no existe exception ->
                if (contacto == null)
                    throw new Exception("El usuario no existe");

                // Elimino el contacto ->
                new ContactoService(_context).Delete(contacto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }

            return NoContent();
        }

    }
}
