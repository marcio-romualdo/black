using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AT_002.Models;

namespace AT_002.Controllers
{
    public class VodkaController : Controller
    {
        private readonly ILogger<RefrigerantesController> _logger;

        public VodkaController(ILogger<RefrigerantesController> logger)
        {
            _logger = logger;
        }
       
         /* Vodka*/
           public IActionResult Ciroc()
        {
            return View();
        }
          public IActionResult Greygoose()
        {
            return View();
        }
          public IActionResult Kislla ()
        {
            return View();
        }
          public IActionResult NordKa()
        {
            return View();
        }
          public IActionResult Raykoff()
        {
            return View();
        }
          public IActionResult Smirnoff()
        {
            return View();
        }
        /* Gim*/
         public IActionResult Gordons()
        {
            return View();
        }
        public IActionResult Eternety()
        {
            return View();
        }
         public IActionResult   Tanquery()
        {
            return View();
        }
      
    }
}