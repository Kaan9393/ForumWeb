using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class Post
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("subCategoryId")]
        public Guid SubCategoryId { get; set; }

        [JsonPropertyName("user")]
        public Guid User { get; set; }
    }
}
