using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
