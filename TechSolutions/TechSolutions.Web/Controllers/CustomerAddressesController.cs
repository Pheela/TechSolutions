using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechSolutions.Model;
using TechSolutions.Web.Data;

namespace TechSolutions.Web.Controllers
{
    public class CustomerAddressesController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomerAddressesController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.GetAsync("api/customeraddresses");

            if (response.IsSuccessStatusCode)
            {
                var customeraddresses = await response.Content.ReadAsAsync<IEnumerable<CustomerAddress>>();
                return View(customeraddresses);
            }
            else
            {
                return View(Array.Empty<CustomerAddress>());
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.GetAsync($"api/customerAddresses/{id}");

            if (response.IsSuccessStatusCode)
            {
                var customerAddress = await response.Content.ReadAsAsync<CustomerAddress>();
                return View(customerAddress);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerAddress customerAddress)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.PostAsJsonAsync("api/customerAddresses", customerAddress);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(customerAddress);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.DeleteAsync($"api/customerAddresses/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
