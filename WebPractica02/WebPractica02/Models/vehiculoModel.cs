using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using WebPractica02.Entity;
using Newtonsoft.Json;

namespace WebPractica02.Models
{
    public class consulta
    {
        private string urlApi = ConfigurationManager.AppSettings["urlApi"];
        public string RegistroCarro(vehiculoEntities vehiculo)
        {
            using (var client = new HttpClient())
            {
                string url = urlApi + "RegistroCarro";
                JsonContent contenido = JsonContent.Create(vehiculo);
                using (HttpResponseMessage resp = client.PostAsync(url, contenido).Result)
                {
                    return resp.Content.ReadFromJsonAsync<string>().Result;
                }
            }
        }

    }
}