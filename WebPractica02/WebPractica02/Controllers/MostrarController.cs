using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebPractica02.Models;

namespace WebPractica02.Controllers
{
    public class MostrarController : Controller
    {
        consultaModel model = new consultaModel();

        [HttpGet]
        public ActionResult RealizarConsulta()
        {
            var datos = model.RealizarConsulta();
            return View(datos);
        }


    }
}
