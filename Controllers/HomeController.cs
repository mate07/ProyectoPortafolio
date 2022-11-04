using Microsoft.AspNetCore.Mvc;
using ProyectoPortafolio.Models;
using ProyectoPortafolio.Servicios;
using System.Diagnostics;

namespace ProyectoPortafolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IServicioEmail servicioEmail;

        public HomeController(ILogger<HomeController> logger,
               IServicioEmail servicioEmail)
        {
            _logger = logger;
            this.servicioEmail = servicioEmail;
        }

        public IActionResult Index()
        {
            //Bloque Información
            var p = new Personsa()
            {
                Nombre = "Vladimir Mate Villanueva",
                Edad = 30,
                Profesion = "Ingeniero en CC de la Computación",
                lugarUni = "UNAB"
            };

            return View(p);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contacto()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contacto(Contacto contacto)
        {
            await servicioEmail.Enviar(contacto);
            return RedirectToAction("Gracias");
        }

        public IActionResult Gracias()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}