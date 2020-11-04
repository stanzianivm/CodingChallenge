using ApiContactos.Models;
using ApiContactos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContactos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly ContactosContext _context;

        public CiudadController(ContactosContext context)
        {
            _context = context;
        }

        // GET: api/Ciudad
        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> GetAll()
        {
            var ciudades = new CiudadService(_context).GetAll();

            if (ciudades == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }

            return ciudades;
        }

        // GET: api/ciudad/GetAllByProvinciaId?provId=1
        [Route("GetAllByProvinciaId")]
        [HttpGet]
        public ActionResult<IEnumerable<Ciudad>> GetAllByProvinciaId(int provId)
        {
            var ciudades = new CiudadService(_context).GetAllByProvinciaId(provId);

            if (ciudades == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }

            return ciudades;
        }

        // GET: api/Ciudad/5
        [HttpGet("{id}")]
        public ActionResult<Ciudad> GetById(int id)
        {
            var ciudad = new CiudadService(_context).GetById(id);

            if (ciudad == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }

            return ciudad;
        }
    }
}
