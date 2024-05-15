using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutHeadPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
