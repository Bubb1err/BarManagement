using BarManagement.UI.Constants;
using BarManagement.UI.Models.ApiErrors;
using BarManagement.UI.Models.Coctails;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BarManagement.UI.Controllers
{
    public class CoctailsController : Controller
    {
        private readonly IConfiguration _configuration;

        public CoctailsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            HttpClient client = new HttpClient();
            string token = Request.Cookies[CookiesNames.JwtToken];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            var response = await client.GetAsync(_configuration["BarManagementAPI:CoctailsEndpoint"]);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<IEnumerable<CoctailViewModel>>(responseContent);

                return View(responseObject);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var errorResult = JsonConvert.DeserializeObject<ErrorResponse>(errorMessage);

                ModelState.AddModelError(string.Empty, errorResult.Message);

                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetCoctailDetails(Guid coctailId)
        {
            HttpClient client = new HttpClient();
            string token = Request.Cookies[CookiesNames.JwtToken];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            var response = await client.GetAsync($"{_configuration["BarManagementAPI:CoctailsEndpoint"]}/{coctailId}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<GetCoctailDetailsViewModel>(responseContent);

                return View(responseObject);
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var errorResult = JsonConvert.DeserializeObject<ErrorResponse>(errorMessage);

                ModelState.AddModelError(string.Empty, errorResult.Message);

                return View();
            }
        }
    }
}
