using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
