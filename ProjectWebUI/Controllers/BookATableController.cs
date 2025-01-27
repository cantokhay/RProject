using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.BookingVM;
using ProjectWebUI.VMs.ContactVM;
using System.Text;

namespace ProjectWebUI.Controllers
{
    public class BookATableController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BookATableController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7271/api/Contact");
            response.EnsureSuccessStatusCode();
            var jsonData = await response.Content.ReadAsStringAsync();
            var location = JsonConvert.DeserializeObject<List<ResultContactVM>>(jsonData);
            ViewBag.Location = location[0].ContactLocation;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateBookingVM createBookingVM)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBookingVM);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:7271/api/Booking", content);
            var responseMap = await client.GetAsync("https://localhost:7271/api/Contact");
            responseMap.EnsureSuccessStatusCode();
            var jsonDataMap = await responseMap.Content.ReadAsStringAsync();
            var location = JsonConvert.DeserializeObject<List<ResultContactVM>>(jsonDataMap);
            ViewBag.Location = location[0].ContactLocation;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                ModelState.AddModelError(string.Empty, errorContent);
                return View();
            }
        }
    }
}
