using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AT_002.Models;

namespace AT_002.Controllers
{
    public class CarvaogeloController : Controller
    {
        private readonly ILogger<CervejasController> _logger;

        public CarvaogeloController(ILogger<CervejasController> logger)
        {
            _logger = logger;
        }
       
     public IActionResult GeloBarra()
        {
            return View();
        }     
        public IActionResult Carvao()
        {
            return View();
        }       
             public IActionResult GeloCubo()
        {
            return View();
        }       
      
    }

}