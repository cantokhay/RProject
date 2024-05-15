using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.DiscountVM;

namespace ProjectWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOfferPartialComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultOfferPartialComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Discount");

            var jsonData = await response.Content.ReadAsStringAsync();
            var discountList = JsonConvert.DeserializeObject<List<ResultDiscountVM>>(jsonData);
            return View(discountList);
        }
    }
}
