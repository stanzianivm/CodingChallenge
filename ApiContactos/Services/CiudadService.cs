using ApiContactos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContactos.Services
{
    public class CiudadService
    {
        private readonly ContactosContext _context;
        public CiudadService(ContactosContext db) => _context = db;

        public List<Ciudad> GetAll()
        {
            try
            {
                return _context.Ciudad.OrderBy(c => c.Nombre).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Ciudad> GetAllByProvinciaId(int provId)
        {
            try
            {
                return _context.Ciudad.OrderBy(c => c.Nombre).Where(p => p.ProvinciaId == provId).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Ciudad GetById(int id)
        {
            try
            {
                return _context.Ciudad.Include("Provincia").Where(p => p.CiudadId == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
