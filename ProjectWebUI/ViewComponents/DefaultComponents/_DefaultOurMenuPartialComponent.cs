using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.ProductVM;

namespace ProjectWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOurMenuPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Product");

            var jsonData = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<List<ResultProductVM>>(jsonData);
            return View(productList);
        }
    }
}
