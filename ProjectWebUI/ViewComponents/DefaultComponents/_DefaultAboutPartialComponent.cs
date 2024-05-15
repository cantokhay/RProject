using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.AboutVM;

namespace ProjectWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultAboutPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultAboutPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/About");

            var jsonData = await response.Content.ReadAsStringAsync();
            var aboutList = JsonConvert.DeserializeObject<List<ResultAboutVM>>(jsonData);
            return View(aboutList);
        }
    }
}
