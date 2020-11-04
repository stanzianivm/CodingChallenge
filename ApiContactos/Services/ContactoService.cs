using ApiContactos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiContactos.Services
{
    public class ContactoService
    {
        private readonly ContactosContext _context;
        public ContactoService(ContactosContext db) => _context = db;

        /// <summary>
        /// Retorna una lista de usuarios con sus filtros
        /// </summary>
        /// <param name="telefono"></param>
        /// <param name="email"></param>
        /// <param name="provinciaId"></param>
        /// <param name="ciudadId"></param>
        /// <returns></returns>
        public List<Contacto> GetAllByFilter(string telefono, string email, string provinciaId, string ciudadId)
        {
            try
            {
                var query = (from t in _context.Contacto select t);

                if (telefono != null && telefono != string.Empty)
                {
                    query = query.Where(q => q.Telefono.Contains(telefono));
                }

                if (email != null && email != string.Empty)
                {
                    query = query.Where(q => q.Email.Contains(email));
                }

                if (provinciaId != null && provinciaId != string.Empty)
                {
                    int provincia = int.Parse(provinciaId);
                    query = query.Where(q => q.Direccion.Ciudad.ProvinciaId == provincia);
                }

                if (ciudadId != null && ciudadId != string.Empty)
                {
                    int ciudad = int.Parse(ciudadId);
                    query = query.Where(q => q.Direccion.CiudadId == ciudad);
                }

                List<Contacto> ls = query.OrderBy(x => x.Nombre)
                                         .Include("Direccion")
                                         .Include("Direccion.Ciudad")
                                         .Include("Direccion.Ciudad.Provincia").ToList();

                return ls;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Retorna un usuario por el id pasado por parámetro
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Contacto GetById(int id)
        {
            try
            {
                return _context.Contacto.Include("Direccion")
                                        .Include("Direccion.Ciudad")
                                        .Include("Direccion.Ciudad.Provincia")
                                        .Where(c => c.ContactoId == id).FirstOrDefault();
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Modifica un usuario pasado por parámetro
        /// </summary>
        /// <param name="contacto"></param>
        public void Modified(Contacto contacto)
        {
            try
            {
                var dir = _context.Direccion.Where(x => x.DireccionId == contacto.DireccionId).FirstOrDefault();
                if (dir != null)
                {
                    _context.Entry(dir).State = EntityState.Detached;
                }
                _context.Entry(contacto.Direccion).State = EntityState.Modified;

                var con = _context.Contacto.Where(x => x.ContactoId == contacto.ContactoId).FirstOrDefault();
                if (con != null)
                {
                    _context.Entry(con).State = EntityState.Detached;
                }
                _context.Entry(contacto).State = EntityState.Modified;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Agrega un usuario pasado por parámetro
        /// </summary>
        /// <param name="contacto"></param>
        public void Add(Contacto contacto)
        {
            try
            {
                _context.Contacto.Add(contacto);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Elimina un contacto pasado por parámetro
        /// </summary>
        /// <param name="contacto"></param>
        public void Delete(Contacto contacto)
        {
            try
            {
                _context.Entry(contacto.Direccion).State = EntityState.Deleted;
                _context.Entry(contacto).State = EntityState.Deleted;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
