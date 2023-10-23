using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WebPractica02.Entity;

namespace WebPractica02.Models
{
    public class VendedorModel
    {
        private string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public string RegistrarVendedor(vendedorEntities vendedor)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "RegistrarVendedor";
                JsonContent contenido = JsonContent.Create(vendedor);
                using (HttpResponseMessage resp = client.PostAsync(url, contenido).Result)
                {
                    return resp.Content.ReadFromJsonAsync<string>().Result;
                }
            }
        }
    }
}
