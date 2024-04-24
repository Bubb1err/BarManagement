using BarManagement.UI.Constants;
using BarManagement.UI.Models.ApiErrors;
using BarManagement.UI.Models.Commodity;
using BarManagement.UI.Models.Receipt;
using BarManagement.UI.Services.JwtParser;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BarManagement.UI.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IJwtParser _jwtParser;

        public ReceiptController(IConfiguration configuration,
            IJwtParser jwtParser)
        {
            _configuration = configuration;
            _jwtParser = jwtParser;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            string token = Request.Cookies[CookiesNames.JwtToken];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync(_configuration["BarManagementAPI:ReceiptsEndpoint"]);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<IEnumerable<ReceiptViewModel>>(responseContent);

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
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateReceiptViewModel receiptViewModel)
        {
            string token = Request.Cookies[CookiesNames.JwtToken];
            string id = _jwtParser.GetIdFromToken(token);

            receiptViewModel.BarmenId = Guid.Parse(id);

            if (!ModelState.IsValid)
            {
                return View(receiptViewModel);
            }

            HttpClient client = new HttpClient();
            
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            var json = JsonConvert.SerializeObject(receiptViewModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_configuration["BarManagementAPI:ReceiptsEndpoint"], content);

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

                return View(receiptViewModel);
            }
        }
    }
}
