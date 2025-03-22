using Microsoft.AspNetCore.Mvc;

namespace Orcamento.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
