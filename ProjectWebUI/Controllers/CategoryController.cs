using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.CategoryVM;
using System.Text;

namespace ProjectWebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryVM>>(jsonData);
                return View(categories);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
			return View();
		}

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryVM createCategoryVM)
        {
            createCategoryVM.CategoryStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCategoryVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7271/api/Category", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteCategory(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7271/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCategory(int id)
        {
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync($"https://localhost:7271/api/Category/{id}");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var category = JsonConvert.DeserializeObject<UpdateCategoryVM>(jsonData);
                return View(category);
            }
            return View();
		}

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryVM updateCategoryVM)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCategoryVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7271/api/Category", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
