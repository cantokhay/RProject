using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.SocialMediaVM;

namespace ProjectWebUI.ViewComponents.UILayoutComponents
{
    public class _UILayoutSocialMediaPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutSocialMediaPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/SocialMedia");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var socialMediaList = JsonConvert.DeserializeObject<List<ResultSocialMediaVM>>(jsonData);
                return View(socialMediaList);
            }
            return View();
        }
    }
}
