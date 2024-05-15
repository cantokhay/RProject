using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutNavbarPartialComponent    : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
