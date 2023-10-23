using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebPractica02.Entity;
using WebPractica02.Models;

namespace WebPractica02.Controllers
{
    public class RegistrosController : Controller
    {
        [HttpGet]
        public ActionResult RegistroCarro()
        {
            ViewBag.Message = "Registre el Carro";

            return View();
        }

        [HttpPost]
        public ActionResult RegistroCarro(vehiculoEntities vehiculo)
        {
            consulta model = new consulta();

            if (ModelState.IsValid) // Verifica si hay errores en el modelo
            {
                model.RegistroCarro(vehiculo);
                ViewBag.ConfirmationMessage = "Vehiculo registrado con éxito";
            }
            else
            {
                ViewBag.ErrorMessage = "Se encontraron errores en el formulario. Corríjalos antes de continuar.";
            }

            return View();
        }

        [HttpGet]
        public ActionResult RegistroVendedores()
        {
            ViewBag.Message = "Registre el vendedor";

            return View();
        }

        [HttpPost]
        public ActionResult RegistroVendedores(vendedorEntities vendedor)
        {
            VendedorModel model = new VendedorModel();

            if (ModelState.IsValid) // Verifica si hay errores en el modelo
            {
                model.RegistrarVendedor(vendedor);
                ViewBag.ConfirmationMessage = "Vendedor registrado con éxito";
            }
            else
            {
                ViewBag.ErrorMessage = "Se encontraron errores en el formulario. Corríjalos antes de continuar.";
            }

            return View();
        }
    }
}

