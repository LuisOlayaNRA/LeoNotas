using Microsoft.AspNetCore.Mvc;

namespace CICDNotas.Controllers
{
    public class SesionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
