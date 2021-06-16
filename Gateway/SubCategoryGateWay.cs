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
    public class SubCategoryGateWay : ISubCategory
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public SubCategoryGateWay(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        
        public async Task<List<SubCategory>> GetSubCategories()
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/SubCategories");
            //var response = await _httpClient.GetAsync("https://localhost:44341/api/SubCategories");
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<SubCategory>>(apiResponse);
        }

        public async Task<List<SubCategory>> GetAllSubCategoriesById(Guid categoryId)
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/SubCategories" + "/CategoryId/" + categoryId);
            //var response = await _httpClient.GetAsync("https://localhost:44341/api/SubCategories" + "/CategoryId/" + categoryId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<SubCategory>>(apiResponse);
        }

        //string text, guid categoryId.
        //new {Text = text, CategoryId = categoryId })
        public async Task<SubCategory> PostSubCategory(SubCategory subCategory)
        {
            var response = await _httpClient.PostAsJsonAsync("https://snackiskg.azurewebsites.net/api/SubCategories", subCategory);
            //var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/SubCategories", subCategory);
            SubCategory returnValue = await response.Content.ReadFromJsonAsync<SubCategory>();

            return returnValue;
        }

        public async Task DeleteSubCategory(Guid deleteId)
        {
            var response = await _httpClient.DeleteAsync("https://snackiskg.azurewebsites.net/api/SubCategories" + "/" + deleteId);
            //var response = await _httpClient.DeleteAsync("https://localhost:44341/api/SubCategories" + "/" + deleteId);
            
        }

        public async Task PutSubCategory(Guid editId, SubCategory subCategory)
        {
            await _httpClient.PutAsJsonAsync("https://snackiskg.azurewebsites.net/api/SubCategories" + "/" + editId, subCategory);
            //await _httpClient.PutAsJsonAsync("https://localhost:44341/api/SubCategories" + "/" + editId, subCategory);
        }


    }
}
