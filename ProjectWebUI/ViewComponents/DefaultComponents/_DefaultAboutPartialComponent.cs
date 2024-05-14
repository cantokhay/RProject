using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
