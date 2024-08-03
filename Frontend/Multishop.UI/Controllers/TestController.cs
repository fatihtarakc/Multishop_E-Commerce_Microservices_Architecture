using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Multishop.UI.Controllers
{
    public class TestController : Controller
    {
        private readonly IHttpClientFactory httpClientFactory;
        public TestController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            string token = "";
            using (var httpClient = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    RequestUri = new Uri("https://localhost:7000/connect/token"),
                    Method = HttpMethod.Post,
                    Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                        { "client_id", "Multishop.VisitorId" },
                        { "client_secret", "multishop.clientsecrets" },
                        { "grant_type", "client_credentials" }
                    })
                };

                using (var response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var tokenresponse = JObject.Parse(content);
                        token = tokenresponse["access_token"].ToString();
                    }
                }
            }

            var client = httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var responseMessage = await client.GetAsync("https://localhost:7001/api/Category/Categories");
            if (!responseMessage.IsSuccessStatusCode) return RedirectToAction("NotFound", "Home", new { area = "" });

            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var categoryVMs = JsonConvert.DeserializeObject<IEnumerable<UI.Models.ViewModels.CategoryVMs.CategoryVM>>(jsonData);
            return View(categoryVMs);
        }
    }
}