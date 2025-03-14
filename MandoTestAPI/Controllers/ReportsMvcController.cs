using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using MandoTestAPI.Models;

namespace MandoTestAPI.Controllers
{
    public class ReportsMvcController : Controller
    {
        private readonly HttpClient _httpClient;

        public ReportsMvcController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
        }

        public async Task<IActionResult> Index()
        {
            var apiUrl = "http://localhost:5081/api/reports/class-report";
            var response = await _httpClient.GetStringAsync(apiUrl);
            var reportData = JsonConvert.DeserializeObject<List<ClassReport>>(response);
            return View(reportData);
        }
    }
}
