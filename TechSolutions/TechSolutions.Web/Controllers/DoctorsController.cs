using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using TechSolutions.Model;

namespace TechSolutions.Web.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DoctorsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.GetAsync("api/doctors");

            if (response.IsSuccessStatusCode)
            {
                var doctors = await response.Content.ReadAsAsync<IEnumerable<Doctor>>();
                return View(doctors);
            }
            else
            {
                return View(Array.Empty<Doctor>());
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.PostAsJsonAsync("api/doctors", doctor);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(doctor);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.GetAsync($"api/doctors/{id}");

            if (response.IsSuccessStatusCode)
            {
                var doctor = await response.Content.ReadAsAsync<Doctor>();
                return View(doctor);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Doctor doctor)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.PutAsJsonAsync($"api/doctors/{id}", doctor);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(doctor);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.DeleteAsync($"api/doctors/{id}");

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
