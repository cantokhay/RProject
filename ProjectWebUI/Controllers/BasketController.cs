﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.AboutVM;
using ProjectWebUI.VMs.BasketVM;
using System.Text;

namespace ProjectWebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Basket/Index/{customerId?}")]
        public async Task<IActionResult> Index(int customerId)
        {
            TempData["customerId"] = customerId;
            TempData.Keep("customerId");
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"https://localhost:7271/api/Basket/BASKET_LIST_BY_CUSTOMER_ID?customerId={customerId}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var basketList = JsonConvert.DeserializeObject<List<ResultBasketVM>>(jsonData);
                return View(basketList);
            }
            return View();
        }

        public async Task<IActionResult> DeleteBasket(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7271/api/Basket/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
    }
}
