using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutScriptPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
