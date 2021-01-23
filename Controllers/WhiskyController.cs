using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AT_002.Models;

namespace AT_002.Controllers
{
    public class WhiskyController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public WhiskyController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
       
         public IActionResult Ballantines()
        {
            return View();
        }
         public IActionResult ChivasRegal()
        {
            return View();
        }
         public IActionResult JackDaniels()
        {
            return View();
        }
         public IActionResult OldParr()
        {
            return View();
        }
          public IActionResult RedLabel()
        {
            return View();
        }
          public IActionResult WhiteHorse()
        {
            return View();
        }

    }
}