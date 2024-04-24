using BarManagement.UI.Constants;
using BarManagement.UI.Models.ApiErrors;
using BarManagement.UI.Models.Authentication;
using BarManagement.UI.Models.Commodity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BarManagement.UI.Controllers
{
    public class CommodityController : Controller
    {
        private readonly IConfiguration _configuration;

        public CommodityController(IConfiguration configuration)
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
            var response = await client.GetAsync(_configuration["BarManagementAPI:CommodityEndpoint"]);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<IEnumerable<CommodityViewModel>>(responseContent);

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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCommodityViewModel createCommodityViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createCommodityViewModel);
            }
            HttpClient client = new HttpClient();
            string token = Request.Cookies[CookiesNames.JwtToken];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            var json = JsonConvert.SerializeObject(createCommodityViewModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_configuration["BarManagementAPI:CommodityEndpoint"], content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                return RedirectToAction("GetAll");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var errorResult = JsonConvert.DeserializeObject<ErrorResponse>(errorMessage);

                ModelState.AddModelError(string.Empty, errorResult.Message);

                return View(createCommodityViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            HttpClient client = new HttpClient();
            string token = Request.Cookies[CookiesNames.JwtToken];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            var response = await client.GetAsync($"{_configuration["BarManagementAPI:CommodityEndpoint"]}/{id}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<UpdateCommodityViewModel>(responseContent);

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

        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateCommodityViewModel updateCommodityViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updateCommodityViewModel);
            }
            HttpClient client = new HttpClient();
            string token = Request.Cookies[CookiesNames.JwtToken];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            var json = JsonConvert.SerializeObject(updateCommodityViewModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(_configuration["BarManagementAPI:CommodityEndpoint"], content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();

                return RedirectToAction("GetAll");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var errorResult = JsonConvert.DeserializeObject<ErrorResponse>(errorMessage);

                ModelState.AddModelError(string.Empty, errorResult.Message);

                return View(updateCommodityViewModel);
            }
        }
    }
}
