using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Web;
using WebPractica02.Entity;


namespace WebPractica02.Models
{
    public class consultaModel
    {
        private string urlApi = ConfigurationManager.AppSettings["urlApi"];

        public List<consultaEntities> RealizarConsulta()
        {
            using (var client = new HttpClient())
            {
                var url = urlApi + "RealizarConsulta";
                var res = client.GetAsync(url).Result;
                return res.Content.ReadFromJsonAsync<List<consultaEntities>>().Result;
            }
        }

    }


}