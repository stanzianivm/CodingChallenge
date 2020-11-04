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
    public class ProvinciaRESTService
    {
        private string urlApi;
        private string controllerName;

        public ProvinciaRESTService()
        {
            urlApi = ConfigurationManager.AppSettings["urlApiContactos"].ToString();
            controllerName = "Provincia";
        }

        public async Task<List<ProvinciaDTO>> GetAll()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string url = string.Format("{0}/{1}", urlApi, controllerName);
                return JsonConvert.DeserializeObject<List<ProvinciaDTO>>(await httpClient.GetStringAsync(url));
            }
        }
    }
}