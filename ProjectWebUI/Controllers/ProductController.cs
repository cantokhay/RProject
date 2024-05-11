using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProjectWebUI.VMs.CategoryVM;
using ProjectWebUI.VMs.ProductVM;
using System.Text;

namespace ProjectWebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Product/PRODUCT_LIST_WITH_CATEGORY");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<ResultProductVM>>(jsonData);
                return View(products);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Category");
            var jsonData = await response.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryVM>>(jsonData);
            List<SelectListItem> selectListItems = (from category in categories
                                                    select new SelectListItem
                                                    {
                                                        Text = category.CategoryName,
                                                        Value = category.CategoryId.ToString()
                                                    }).ToList();
            ViewBag.CategoryList = selectListItems;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductVM createProductVM)
        {
            createProductVM.ProductStatus = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createProductVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7271/api/Product", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"https://localhost:7271/api/Product/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProduct(int id)
        {
            var categoryClient = _httpClientFactory.CreateClient();
            var categoryResponse = await categoryClient.GetAsync("https://localhost:7271/api/Category");
            var categoryJsonData = await categoryResponse.Content.ReadAsStringAsync();
            var categories = JsonConvert.DeserializeObject<List<ResultCategoryVM>>(categoryJsonData);
            List<SelectListItem> selectListItems = (from category in categories
                                                    select new SelectListItem
                                                    {
                                                        Text = category.CategoryName,
                                                        Value = category.CategoryId.ToString()
                                                    }).ToList();
            ViewBag.CategoryList = selectListItems;
            var productClient = _httpClientFactory.CreateClient();
            var productResponse = await productClient.GetAsync($"https://localhost:7271/api/Product/{id}");
            if (productResponse.IsSuccessStatusCode)
            {
                var ProductJsonData = await productResponse.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<UpdateProductVM>(ProductJsonData);
                return View(product);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductVM updateProductVM)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PutAsync("https://localhost:7271/api/Product", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
