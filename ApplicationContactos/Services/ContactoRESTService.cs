using ApplicationContactos.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ApplicationContactos.Services
{
    public class ContactoRESTService
    {
        private string urlApi;
        private string controllerName;

        public ContactoRESTService()
        {
            urlApi = ConfigurationManager.AppSettings["urlApiContactos"].ToString();
            controllerName = "Contacto";
        }

        public async Task<List<ContactoDTO>> GetAllByFilter(string telefono, string email, string provinciaId, string ciudadId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = string.Format("{0}/{1}?telefono={2}&email={3}&provinciaId={4}&ciudadId={5}", urlApi, controllerName, telefono, email, provinciaId, ciudadId);
                return JsonConvert.DeserializeObject<List<ContactoDTO>>(await httpClient.GetStringAsync(url));
            }
        }

        public async Task<ContactoDTO> GetById(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = string.Format("{0}/{1}/{2}", urlApi, controllerName, id);
                return JsonConvert.DeserializeObject<ContactoDTO>(await httpClient.GetStringAsync(url));
            }
        }

        public async Task<bool> Add(ContactoDTO req)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(req);

                string url = string.Format("{0}/{1}", urlApi, controllerName);

                HttpContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await httpClient.PostAsync(url, httpcontent);
                resp.EnsureSuccessStatusCode();

                return true;
            }
        }

        public async Task<bool> Modified(ContactoDTO req)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(req);

                string url = string.Format("{0}/{1}", urlApi, controllerName);

                HttpContent httpcontent = new StringContent(json, Encoding.UTF8, "application/json");
                HttpResponseMessage resp = await httpClient.PutAsync(url, httpcontent);
                resp.EnsureSuccessStatusCode();

                return true;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = string.Format("{0}/{1}/{2}", urlApi, controllerName, id);
                HttpResponseMessage resp = await httpClient.DeleteAsync(url);
                resp.EnsureSuccessStatusCode();

                return true;
            }
        }

    }
}