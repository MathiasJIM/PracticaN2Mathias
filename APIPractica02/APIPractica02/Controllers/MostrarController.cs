using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPractica02.Controllers
{
    public class MostrarController : ApiController
    {
        [HttpGet]
        [Route("RealizarConsulta")]
        public List<Consultas> ConsultaUsuarios()
        {
            try
            {
                using (var context = new Practica02PAMathiasEntities())
                {
                    context.Configuration.LazyLoadingEnabled = false;
                    var datos = (from x in context.Consultas
                                 select x).ToList();

                    return datos;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
