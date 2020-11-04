using ApplicationContactos.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ApplicationContactos.Services
{
    public class CiudadRESTService
    {
        private string urlApi;
        private string controllerName;

        public CiudadRESTService()
        {
            urlApi = ConfigurationManager.AppSettings["urlApiContactos"].ToString();
            controllerName = "Ciudad";
        }

        public async Task<List<CiudadDTO>> GetAll()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = string.Format("{0}/{1}", urlApi, controllerName);
                return JsonConvert.DeserializeObject<List<CiudadDTO>>(await httpClient.GetStringAsync(url));
            }
        }

        public async Task<List<CiudadDTO>> GetAllByProvinciaId(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var path = "GetAllByProvinciaId";
                string url = string.Format("{0}/{1}/{2}?provId={3}", urlApi, controllerName, path, id);
                return JsonConvert.DeserializeObject<List<CiudadDTO>>(await httpClient.GetStringAsync(url));
            }
        }

        public async Task<CiudadDTO> GetById(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = string.Format("{0}/{1}/{2}", urlApi, controllerName, id);
                return JsonConvert.DeserializeObject<CiudadDTO>(await httpClient.GetStringAsync(url));
            }
        }
    }
}