using ApiContactos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContactos.Services
{
    public class ProvinciaService
    {
        private readonly ContactosContext _context;
        public ProvinciaService(ContactosContext db) => _context = db;

        public List<Provincia> GetAll()
        {
            try
            {
                return _context.Provincia.OrderBy(c => c.Nombre).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
