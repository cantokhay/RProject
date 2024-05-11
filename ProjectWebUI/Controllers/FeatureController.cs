using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.FeatureVM;
using System.Text;

namespace ProjectWebUI.Controllers
{
	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7271/api/Feature");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var featureList = JsonConvert.DeserializeObject<List<ResultFeatureVM>>(jsonData);
				return View(featureList);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateFeature()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureVM createFeatureVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureVM);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PostAsync("https://localhost:7271/api/Feature", content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.DeleteAsync($"https://localhost:7271/api/Feature/{id}");
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7271/api/Feature/{id}");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var feature = JsonConvert.DeserializeObject<UpdateFeatureVM>(jsonData);
				return View(feature);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureVM updateFeatureVM)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFeatureVM);
			var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var response = await client.PutAsync("https://localhost:7271/api/Feature", content);
			if (response.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
