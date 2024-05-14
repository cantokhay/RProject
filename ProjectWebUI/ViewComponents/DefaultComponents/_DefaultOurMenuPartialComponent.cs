using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
