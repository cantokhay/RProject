using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.AboutVM;
using ProjectWebUI.VMs.SliderVM;    

namespace ProjectWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderPartialComponent : ViewComponent
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Sliders");

            var jsonData = await response.Content.ReadAsStringAsync();
            var sliderList = JsonConvert.DeserializeObject<List<ResultSliderVM>>(jsonData);
            return View(sliderList);
        }
    }
}
