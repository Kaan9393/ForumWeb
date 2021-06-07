using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class SubCategory
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("categoryId")]
        public Guid CategoryId { get; set; }
    }
}
