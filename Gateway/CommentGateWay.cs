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
    public class CommentGateWay : IComment
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public CommentGateWay(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<List<Comment>> GetComments()
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/Comments");
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Comment>>(apiResponse);
        }

        public async Task<Comment> GetOneCommentById(Guid commentId)
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/Comments" + "/" + commentId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Comment>(apiResponse);
        }

        //Ny*******
        public async Task<List<Comment>> GetCommentsByPostId(Guid postId)
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/Comments" + "/PostId/" + postId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Comment>>(apiResponse);
        }
        public async Task<Comment> PostComment(Comment comment)
        {
            var response = await _httpClient.PostAsJsonAsync("https://snackiskg.azurewebsites.net/api/Comments", comment);
            Comment returnValue = await response.Content.ReadFromJsonAsync<Comment>();

            return returnValue;
        }


        public async Task DeleteComment(Guid deleteId)
        {
            var response = await _httpClient.DeleteAsync("https://snackiskg.azurewebsites.net/api/Comments" + "/" + deleteId);
            
        }

        public async Task PutComment(Guid editId, Comment comment)
        {
            await _httpClient.PutAsJsonAsync("https://snackiskg.azurewebsites.net/api/Comments" + "/" + editId, comment);
        }
    }
}
