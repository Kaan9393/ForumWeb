using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class Category
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

    }
}
