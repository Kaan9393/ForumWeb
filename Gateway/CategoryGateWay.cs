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
    public class CategoryGateWay : ICategory
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public CategoryGateWay(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }


        public async Task<List<Category>> GetCategories()
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/Categories");
            //var response = await _httpClient.GetAsync("https://localhost:44341/api/Categories");
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Category>>(apiResponse);
        }


        public async Task<Category> PostCategory(Category category)
        {
            var response = await _httpClient.PostAsJsonAsync("https://snackiskg.azurewebsites.net/api/Categories", category);
            //var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/Categories", category);
            Category returnValue = await response.Content.ReadFromJsonAsync<Category>();

            return returnValue;
        }


        public async Task DeleteCategory(Guid DeleteCatId)
        {
            var response = await _httpClient.DeleteAsync("https://snackiskg.azurewebsites.net/api/Categories" + "/" + DeleteCatId);
            //var response = await _httpClient.DeleteAsync("https://localhost:44341/api/Categories" + "/" + DeleteCatId);

        }

        public async Task PutCategory(Guid editId, Category category)
        {
            await _httpClient.PutAsJsonAsync("https://snackiskg.azurewebsites.net/api/Categories" + "/" + editId, category);
            //await _httpClient.PutAsJsonAsync("https://localhost:44341/api/Categories" + "/" + editId, category);
        }

    }
}
