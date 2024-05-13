using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
