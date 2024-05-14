using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookATablePartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
