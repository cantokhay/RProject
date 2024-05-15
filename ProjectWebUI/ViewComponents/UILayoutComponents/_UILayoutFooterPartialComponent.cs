using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.ContactVM;

namespace ProjectWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutFooterPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutFooterPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Contact");

            var jsonData = await response.Content.ReadAsStringAsync();
            var contactList = JsonConvert.DeserializeObject<List<ResultContactVM>>(jsonData);
            return View(contactList);
        }
    }
}