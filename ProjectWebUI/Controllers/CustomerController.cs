using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.CustomerVM;
using System.Text;

namespace ProjectWebUI.Controllers
{
	public class CustomerController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public CustomerController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
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

		[HttpGet]
		public IActionResult CreateCustomer()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateCustomer(CreateCustomerVM createCustomerVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createCustomerVM);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7271/api/Customers", content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteCustomer(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7271/api/Customers/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateCustomer(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7271/api/Customers/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var customer = JsonConvert.DeserializeObject<UpdateCustomerVM>(jsonData);
				return View(customer);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateCustomer(UpdateCustomerVM updateAboutVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateAboutVM);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7271/api/Customers", content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> CustomerListByStatus()
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
