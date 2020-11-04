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
    public class ProvinciaController : ControllerBase
    {
        private readonly ContactosContext _context;

        public ProvinciaController(ContactosContext context)
        {
            _context = context;
        }

        // GET: api/Provincia
        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> GetAll()
        {
            var provincias = new ProvinciaService(_context).GetAll();

            if (provincias == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "");
            }

            return provincias;
        }

    }
}
