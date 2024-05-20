using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
