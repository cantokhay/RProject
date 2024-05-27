using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.OrderVM;

namespace ProjectWebUI.Controllers
{
	public class OrdersController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public OrdersController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7271/api/Orders");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var orderList = JsonConvert.DeserializeObject<List<ResultOrderVM>>(jsonData);
				return View(orderList);
			}
			return View();
		}

		public async Task<IActionResult> OrderTaken(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7271/api/Orders/ORDER_TAKEN/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> OrderPaid(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7271/api/Orders/ORDER_PAID/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
