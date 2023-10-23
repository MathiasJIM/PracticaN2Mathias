using APIPractica02.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPractica02.Controllers
{
    public class RegistroController : ApiController
    {
        [HttpPost]
        [Route("RegistrarVendedor")]
        public string RegistrarVendedor(vendedorEntities vendedor)
        {
            using (var context = new Practica02PAMathiasEntities())
            {
                //Vendedores tvendedor = new Vendedores();
                //tvendedor.Cedula = vendedor.Cedula;
                //tvendedor.Nombre = vendedor.Nombre;
                //tvendedor.Correo = vendedor.Correo; 
                //tvendedor.Estado = vendedor.Estado;

                //context.Vendedores.Add(tvendedor);
                //context.SaveChanges();

                context.VendedorPA(vendedor.Cedula, vendedor.Nombre, vendedor.Correo, vendedor.Estado);

                return "Registro exitoso";
            }
        }

        [HttpPost]
        [Route("RegistroCarro")]
        public string RegistroCarro(vehiculoEntities vehiculo)
        {
            using (var context = new Practica02PAMathiasEntities())
            {

                context.InsertarVehiculo(vehiculo.Marca, vehiculo.Modelo, vehiculo.Color, vehiculo.Precio, vehiculo.Vendedor);

                return "Registro exitoso";
            }
        }
      

    }
}
