using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AT_002.Models;

namespace AT_002.Controllers
{
    public class CervejasController : Controller
    {
        private readonly ILogger<CervejasController> _logger;

        public CervejasController(ILogger<CervejasController> logger)
        {
            _logger = logger;
        }
       
     public IActionResult Skol()
        {
            return View();
        }     
        public IActionResult Brahma()
        {
            return View();
        }       
             public IActionResult Heineken()
        {
            return View();
        }       
                public IActionResult Itaipava()
        {
            return View();
        }  
                public IActionResult Budweiser()
        {
            return View();
        }  
             public IActionResult  Antarctica()
        {
            return View();
        } 
            public IActionResult Lokal()
        {
            return View();
        } 
             public IActionResult Amstel()
        {
            return View();
        }
             public IActionResult Bohemia()
        {
            return View();
        }
            public IActionResult Imperio()
        {
            return View();
        }
            public IActionResult Petra()
        {
            return View();
        }
    }

}