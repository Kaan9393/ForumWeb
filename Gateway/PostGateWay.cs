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
    public class PostGateWay : IPost
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public PostGateWay(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }
        

        public async Task<List<Post>> GetPosts()
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/Posts");
            //var response = await _httpClient.GetAsync("https://localhost:44341/api/Posts");
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Post>>(apiResponse);
        }
        public async Task<List<Post>> GetPostsBySubCategoryId(Guid subCategoryId)
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/Posts" + "/SubCategoryId/" + subCategoryId);
            //var response = await _httpClient.GetAsync("https://localhost:44341/api/Posts" + "/SubCategoryId/" + subCategoryId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Post>>(apiResponse);
        }

        //Get one post to write comments in
        public async Task<Post> GetOnePostByPostId(Guid postId)
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/Posts" + "/" + postId);
            //var response = await _httpClient.GetAsync("https://localhost:44341/api/Posts" + "/" + postId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Post>(apiResponse);
        }

        public async Task<Post> PostPosts(Post post)
        {
            var response = await _httpClient.PostAsJsonAsync("https://snackiskg.azurewebsites.net/api/Posts", post);
            //var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/Posts", post);
            Post returnValue = await response.Content.ReadFromJsonAsync<Post>();

            return returnValue;
        }


        public async Task DeletePost(Guid deleteId)
        {
            var response = await _httpClient.DeleteAsync("https://snackiskg.azurewebsites.net/api/Posts" + "/" + deleteId);
            //var response = await _httpClient.DeleteAsync("https://localhost:44341/api/Posts" + "/" + deleteId);
            //Post returnValue = await response.Content.ReadFromJsonAsync<Post>();

            //return returnValue;
        }

        public async Task PutPost(Guid editId, Post post)
        {
            await _httpClient.PutAsJsonAsync("https://snackiskg.azurewebsites.net/api/Posts" + "/" + editId, post);
            //await _httpClient.PutAsJsonAsync("https://localhost:44341/api/Posts" + "/" + editId, post);
        }

    }
}
