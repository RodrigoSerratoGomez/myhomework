using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using myhomework.Models;

namespace myhomework.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult GenerarProducto (Producto objProducto)
        {
            double masIGV = 0.0;
            masIGV = Math.Round((objProducto.Precio * 0.18), 2);
            
            ViewData["Message"] = objProducto.Peso + " " + objProducto.Unidad + " de " + objProducto.Nombre + " tiene un procio total de: " + masIGV + " incluyendo IGV.";

            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}