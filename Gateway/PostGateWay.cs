﻿using ForumWeb.Models;
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
            var response = await _httpClient.GetAsync("https://localhost:44341/api/Posts");
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Post>>(apiResponse);
        }

        public async Task<Post> PostPosts(Post post)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/Posts", post);
            Post returnValue = await response.Content.ReadFromJsonAsync<Post>();

            return returnValue;
        }

        public async Task<Post> DeletePost(int deleteId)
        {
            var response = await _httpClient.DeleteAsync("https://localhost:44341/api/Posts" + "/" + deleteId);
            Post returnValue = await response.Content.ReadFromJsonAsync<Post>();

            return returnValue;
        }

        public async Task PutPost(int editId, Post post)
        {
            await _httpClient.PutAsJsonAsync("https://localhost:44341/api/Posts" + "/" + editId, post);
        }


        ////Post API
        //Task<string> getPostString = client.GetStringAsync($"https://localhost:44341/api/Posts");
        //string postString = await getPostString;
        //Post = JsonSerializer.Deserialize<Post>(postString, options);
        //    //<---
    }
}
