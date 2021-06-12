using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class Report
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("postId")]
        public Guid PostId { get; set; }

        [JsonPropertyName("commentId")]
        public Guid CommentId { get; set; }

        [JsonPropertyName("user")]
        public Guid User { get; set; }
    }
}
