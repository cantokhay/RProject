using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.BasketVM;
using ProjectWebUI.VMs.ProductVM;
using System.Text;

namespace ProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Menu/Index/{customerId?}")]
        public async Task<IActionResult> Index(int customerId)
        {
            TempData["customerId"] = customerId;
            TempData.Keep("customerId");

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Product/PRODUCT_LIST_WITH_CATEGORY");

            var jsonData = await response.Content.ReadAsStringAsync();
            var productList = JsonConvert.DeserializeObject<List<ResultProductVM>>(jsonData);
            return View(productList);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] CreateBasketVM createBasketVM)
        {
            int customerId = int.Parse(TempData["customerId"].ToString());
            TempData.Keep("customerId");

            var client = _httpClientFactory.CreateClient();
            var clientStatus = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7271/api/Basket", content);
            await clientStatus.GetAsync("https://localhost:7271/api/Customers/CHANGE_CUSTOMER_STATUS_TO_HASORDER?customerId=" + customerId);

            if (response.IsSuccessStatusCode)
            {
                return Ok();
            }

            return StatusCode((int)response.StatusCode, "Ürün sepete eklenemedi!");
        }
    }
}
