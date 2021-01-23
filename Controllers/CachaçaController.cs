using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AT_002.Models;

namespace AT_002.Controllers
{
    public class CachaçaController : Controller
    {
        private readonly ILogger<CervejasController> _logger;

        public CachaçaController(ILogger<CervejasController> logger)
        {
            _logger = logger;
        }
       
     public IActionResult Cabaré()
        {
            return View();
        }     
        public IActionResult VelhoBarreiro()
        {
            return View();
        }       
             public IActionResult Pirassunga51()
        {
            return View();
        }       
                public IActionResult PergolaVinho()
        {
            return View();
        }  
                public IActionResult CampoLargo()
        {
            return View();
        }  
             public IActionResult  Antarctica()
        {
            return View();
        } 
            public IActionResult CantinhodaVale()
        {
            return View();
        } 
    }

}