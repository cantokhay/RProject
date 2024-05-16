using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.ViewComponents.MenuComponents
{
    public class _MenuNavbarPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
