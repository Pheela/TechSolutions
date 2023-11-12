using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using TechSolutions.Model;

namespace TechSolutions.Web.Controllers
{
    public class MedicalRecordsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MedicalRecordsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.GetAsync("api/medicalrecords");

            if (response.IsSuccessStatusCode)
            {
                var medicalrecords = await response.Content.ReadAsAsync<IEnumerable<MedicalRecord>>();
                return View(medicalrecords);
            }
            else
            {
                return View(Array.Empty<MedicalRecord>());
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.GetAsync($"api/medicalRecords/{id}");

            if (response.IsSuccessStatusCode)
            {
                var medicalRecords = await response.Content.ReadAsAsync<MedicalRecord>();
                return View(medicalRecords);
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(MedicalRecord medicalRecord)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.PostAsJsonAsync("api/medicalrecords", medicalRecord);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(medicalRecord);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var client = _httpClientFactory.CreateClient("TechSolutionsApi");
            var response = await client.DeleteAsync($"api/medicalRecords/{id}");

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
