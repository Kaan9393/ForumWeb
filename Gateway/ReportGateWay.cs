using ForumWeb.Models;
using ForumWeb.Models.IModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForumWeb.Gateway
{
    public class ReportGateWay : IReport
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public ReportGateWay(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<List<Report>> GetReports()
        {
            var response = await _httpClient.GetAsync("https://localhost:44341/api/Reports");
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Report>>(apiResponse);
        }

        public async Task<Report> GetReportById(Guid reportId)
        {
             var response = await _httpClient.GetAsync("https://localhost:44341/api/Reports" + "/" + reportId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Report>(apiResponse);
        }

        public async Task<Report> PostReport(Report report)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/Reports", report);
            Report returnValue = await response.Content.ReadFromJsonAsync<Report>();

            return returnValue;
        }

        public async Task DeleteReport(Guid reportId)
        {
            var response = await _httpClient.DeleteAsync("https://localhost:44341/api/Reports" + " /" + reportId);

        }
    }
}
