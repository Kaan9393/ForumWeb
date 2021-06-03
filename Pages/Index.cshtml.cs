using ForumWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ForumWeb.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public Category Category { get; set; }
        public SubCategory SubCategory { get; set; }
        public Post Post { get; set; }
        public Comment Comment { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async void OnGetAsync()
        {
            

            var client = new HttpClient();

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            //Category API
            Task<string> getCategoryString = client.GetStringAsync($"https://localhost:44341/api/Categories");
            string categoryString = await getCategoryString;
            Category = JsonSerializer.Deserialize<Category>(categoryString, options);
            //<---


            //SubCategory API
            Task<string> getSubCatString = client.GetStringAsync($"https://localhost:44341/api/SubCategories");
            string subCatString = await getCategoryString;
            SubCategory = JsonSerializer.Deserialize<SubCategory>(subCatString, options);
            //<---


            //Post API
            Task<string> getPostString = client.GetStringAsync($"https://localhost:44341/api/Posts");
            string postString = await getPostString;
            Post = JsonSerializer.Deserialize<Post>(postString, options);
            //<---


            //Comment API
            Task<string> getCommentString = client.GetStringAsync($"https://localhost:44341/api/Comments");
            string commentString = await getCommentString;
            Comment = JsonSerializer.Deserialize<Comment>(commentString, options);
            //<---

        }
    }
}
