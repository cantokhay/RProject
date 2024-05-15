using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.TestimonialVM;

namespace ProjectWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTestimonialPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultTestimonialPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Testimonial");

            var jsonData = await response.Content.ReadAsStringAsync();
            var testimonialList = JsonConvert.DeserializeObject<List<ResultTestimonialVM>>(jsonData);
            return View(testimonialList);
        }
    }
}
