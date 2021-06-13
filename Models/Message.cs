using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForumWeb.Models
{
    public class Message
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("date")]
        public DateTime Date { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("messageToUser")]
        public Guid MessageToUser { get; set; }

        [JsonPropertyName("messageFromUser")]
        public Guid MessageFromUser { get; set; }
    }
}
