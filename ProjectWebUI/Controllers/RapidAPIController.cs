using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectWebUI.VMs.RapidAPIVM;

namespace ProjectWebUI.Controllers
{
    [AllowAnonymous]
    public class RapidAPIController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://tasty.p.rapidapi.com/recipes/list?from=0&size=40&tags=under_30_minutes"),
                Headers =
                {
                    { "x-rapidapi-key", "56eeaae0a2msh1f5a78362b65e64p1c49efjsn933601bf2799" },
                    { "x-rapidapi-host", "tasty.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<RootTastyVM>(body);
                var values = root.Results;
                return View(values.ToList());
            }
        }
    }
}
