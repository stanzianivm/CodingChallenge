using ApplicationContactos.Models;
using ApplicationContactos.Models.DTO;
using ApplicationContactos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApplicationContactos.Controllers
{
    public class HomeController : Controller
    {
        #region - Propiedes -
        private ContactoRESTService contactoService = new ContactoRESTService();
        private CiudadRESTService ciudadService = new CiudadRESTService();
        private ProvinciaRESTService provinciaService = new ProvinciaRESTService();

        #endregion

        #region - Vistas -
        public async Task<ActionResult> Index(FormCollection coleccion)
        {
            try
            {
                var telefono = string.Empty;
                var email = string.Empty;
                var provincia = string.Empty;
                var ciudad = string.Empty;

                if (coleccion.Count > 0)
                {
                    telefono = coleccion["Telefono"].ToString();
                    email = coleccion["Email"].ToString();
                    provincia = coleccion["ProvinciaOption"].ToString();
                    ciudad = coleccion["CiudadOption"].ToString();
                }

                return View(await contactoService.GetAllByFilter(telefono, email, provincia, ciudad));
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<ActionResult> DetalleContacto(int id)
        {
            return View(await contactoService.GetById(id));
        }
        public async Task<ActionResult> ModifiedContacto(int id)
        {
            return View(await contactoService.GetById(id));
        }
        public ActionResult AddContacto()
        {
            return View(new ContactoDTO());
        }

        #endregion

        #region - GET -
        [HttpGet]
        public async Task<JsonResult> GetCiudadesByProvinciaId(int id)
        {
            var listaCiudades = await ciudadService.GetAllByProvinciaId(id);
            return Json(listaCiudades, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<JsonResult> GetCiudades()
        {
            var listaCiudades = await ciudadService.GetAll();
            return Json(listaCiudades, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public async Task<JsonResult> GetProvincias()
        {
            var listaProvincias = await provinciaService.GetAll();
            return Json(listaProvincias, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region - CRUD -
        [HttpPost]
        public async Task<ActionResult> Add(ContactoDTO contacto)
        {
            if (ModelState.IsValid)
            {
                await contactoService.Add(contacto);
                return Redirect("~/home");
            }
            else
            {
                return View("~/views/home/AddContacto.cshtml", contacto);
            }
        }
        [HttpPost]
        public async Task <ActionResult> Modified(ContactoDTO contacto)
        {
            if (ModelState.IsValid)
            {
                await contactoService.Modified(contacto);
                return Redirect("~/home");
            }
            else
            {
                return View("~/views/home/UpdateOrAddContacto.cshtml", contacto);
            }
        }

        public async Task<ActionResult> DeleteContacto(int id)
        {
            await contactoService.Delete(id);
            return Redirect("~/Home");
        }

        #endregion
    }
}