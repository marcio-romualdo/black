using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AT_002.Models;

namespace AT_002.Controllers
{
    public class RefrigerantesController : Controller
    {
        private readonly ILogger<RefrigerantesController> _logger;

        public RefrigerantesController(ILogger<RefrigerantesController> logger)
        {
            _logger = logger;
        }
       
         public IActionResult CocaCola()
        {
            return View();
        }
         public IActionResult   Agua()
        {
            return View();
        }
          public IActionResult   Fantalaranja()
        {
            return View();
        }
          public IActionResult   Guarana()
        {
            return View();
        }
          public IActionResult   FantaUva()
        {
            return View();
        }  public IActionResult   Sprite()
        {
            return View();
        }
      
    }
}