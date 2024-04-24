﻿using BarManagement.UI.Constants;
using BarManagement.UI.Models.ApiErrors;
using BarManagement.UI.Models.Buyings;
using BarManagement.UI.Models.Commodity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace BarManagement.UI.Controllers
{
    public class BuyingsController : Controller
    {
        private readonly IConfiguration _configuration;

        public BuyingsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            string token = Request.Cookies[CookiesNames.JwtToken];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync(_configuration["BarManagementAPI:BuyingsEndpoint"]);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<IEnumerable<BuyingViewModel>>(responseContent);

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
        public  async Task<IActionResult> GetSpendings()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            string token = Request.Cookies[CookiesNames.JwtToken];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            var response = await client.GetAsync(_configuration["BarManagementAPI:BuyingsEndpoint"]);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<IEnumerable<BuyingViewModel>>(responseContent);

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
        public async Task<IActionResult> Create([FromForm] CreateBuyingViewModel createBuyingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createBuyingViewModel);
            }
            HttpClient client = new HttpClient();
            string token = Request.Cookies[CookiesNames.JwtToken];
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            client.BaseAddress = new Uri(_configuration["BarManagementAPI:APIHostUrl"]);
            var json = JsonConvert.SerializeObject(createBuyingViewModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_configuration["BarManagementAPI:BuyingsEndpoint"], content);

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

                return View(createBuyingViewModel);
            }
        }
    }
}
