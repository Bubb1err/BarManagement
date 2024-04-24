using BarManagement.UI.Constants;
using BarManagement.UI.Models.ApiErrors;
using BarManagement.UI.Models.Authentication;
using BarManagement.UI.Models.Commodity;
using BarManagement.UI.Services.JwtParser;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace BarManagement.UI.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IJwtParser _jwtParser;

        public AuthenticationController(
            IConfiguration configuration, 
            IJwtParser jwtParser)
        {
            _configuration = configuration;
            _jwtParser = jwtParser;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromForm]RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            var json = JsonConvert.SerializeObject(registerViewModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_configuration["BarManagementAPI:RegisterEndpoint"], content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<TokenResponse>(responseContent);

                Response.Cookies.Append(CookiesNames.JwtToken, responseObject.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddHours(1)
                });

                string? role = _jwtParser.GetRoleFromToken(responseObject.Token);
                if (string.IsNullOrWhiteSpace(role))
                {
                    return Unauthorized();
                }

                Response.Cookies.Append(CookiesNames.Role, role);

                return RedirectToAction("GetAll", "Receipt");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var errorResult = JsonConvert.DeserializeObject<ErrorResponse>(errorMessage);

                ModelState.AddModelError(string.Empty, errorResult.Message);

                return View(registerViewModel);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginViewModel loginViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            var json = JsonConvert.SerializeObject(loginViewModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_configuration["BarManagementAPI:LoginEndpoint"], content);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<TokenResponse>(responseContent);

                Response.Cookies.Append(CookiesNames.JwtToken, responseObject.Token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.UtcNow.AddHours(1)
                });

                string? role = _jwtParser.GetRoleFromToken(responseObject.Token);
                if (string.IsNullOrWhiteSpace(role))
                {
                    return Unauthorized();
                }

                Response.Cookies.Append(CookiesNames.Role, role);

                return RedirectToAction("GetAll", "Receipt");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var errorResult = JsonConvert.DeserializeObject<ErrorResponse>(errorMessage);

                ModelState.AddModelError(string.Empty, errorResult.Message);

                return View(loginViewModel);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWorkers()
        {
            string token = Request.Cookies[CookiesNames.JwtToken];
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var adminId = _jwtParser.GetIdFromToken(token);
            var response = await client.GetAsync($"{_configuration["BarManagementAPI:GetWorkersEndpoint"]}?adminId={adminId}");

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<IEnumerable<WorkerViewModel>>(responseContent);

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
        public IActionResult AddWorker()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddWorker([FromForm]AddWorkerModel addWorkerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addWorkerModel);
            }
            string token = Request.Cookies[CookiesNames.JwtToken];
            var adminId = _jwtParser.GetIdFromToken(token);
            addWorkerModel.AdminId = adminId;

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var json = JsonConvert.SerializeObject(addWorkerModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_configuration["BarManagementAPI:AddWorkerEndpoint"], content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetWorkers", "Authentication");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                var errorResult = JsonConvert.DeserializeObject<ErrorResponse>(errorMessage);

                ModelState.AddModelError(string.Empty, errorResult.Message);

                return View(addWorkerModel);
            }
        }
    }
}
