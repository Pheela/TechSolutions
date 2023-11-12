using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechSolutions.Model;

namespace TechSolutions.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CustomersController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.GetAsync("api/customers");

            if (response.IsSuccessStatusCode)
            {
                var customers = await response.Content.ReadAsAsync<IEnumerable<Customer>>();
                return View(customers);
            }
            else
            {
                return View(Array.Empty<Customer>());
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.PostAsJsonAsync("api/customers", customer);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(customer);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.GetAsync($"api/customers/{id}");

            if (response.IsSuccessStatusCode)
            {
                var customer = await response.Content.ReadAsAsync<Customer>();
                return View(customer);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.PutAsJsonAsync($"api/customers/{id}", customer);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(customer);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.DeleteAsync($"api/customers/{id}");

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
