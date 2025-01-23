using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class RapidAPIController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
