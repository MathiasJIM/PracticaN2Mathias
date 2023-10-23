using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPractica02.Entities
{
    public class vehiculoEntities
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Precio { get; set; }
        public string Color { get; set; }
        public int Vendedor { get; set; }
    }
}