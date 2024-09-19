using Microsoft.AspNetCore.Mvc;

namespace CICDNotas.Controllers
{
    public class ProfesorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
