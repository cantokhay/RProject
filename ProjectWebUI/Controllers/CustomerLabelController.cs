using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.CustomerVM;
using System.Net.Http;

namespace ProjectWebUI.Controllers
{
    public class CustomerLabelController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerLabelController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CustomerLabelsList()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Customers");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var customerList = JsonConvert.DeserializeObject<List<ResultCustomerVM>>(jsonData);
                return View(customerList);
            }
            return View();
        }
    }
}
