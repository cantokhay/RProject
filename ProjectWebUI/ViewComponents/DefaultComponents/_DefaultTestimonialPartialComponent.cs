using Microsoft.AspNetCore.Mvc;

namespace ProjectWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialPartialComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
