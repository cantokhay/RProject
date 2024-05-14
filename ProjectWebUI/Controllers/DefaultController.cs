using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
