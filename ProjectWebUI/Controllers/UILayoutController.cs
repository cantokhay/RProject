using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
