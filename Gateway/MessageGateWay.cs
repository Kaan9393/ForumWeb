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
    public class MessageGateWay : IMessage
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public MessageGateWay(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

 
        public async Task<List<Message>> GetMessages()
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/Messages");
            //var response = await _httpClient.GetAsync("https://localhost:44341/api/Messages");
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Message>>(apiResponse);
        }

        public async Task<List<Message>> GetMessageByUserId(Guid userId)
        {
            var response = await _httpClient.GetAsync("https://snackiskg.azurewebsites.net/api/Messages" + "/UserId/" + userId);
            //var response = await _httpClient.GetAsync("https://localhost:44341/api/Messages" + "/UserId/" + userId);
            string apiResponse = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<Message>>(apiResponse);
        }

        public async Task<Message> PostMessage(Message message)
        {
            var response = await _httpClient.PostAsJsonAsync("https://snackiskg.azurewebsites.net/api/Messages", message);
            //var response = await _httpClient.PostAsJsonAsync("https://localhost:44341/api/Messages", message);
            Message returnValue = await response.Content.ReadFromJsonAsync<Message>();

            return returnValue;
        }

        public async Task DeleteMessage(Guid messageId)
        {
            var response = await _httpClient.DeleteAsync("https://snackiskg.azurewebsites.net/api/Messages" + "/" + messageId);
            //var response = await _httpClient.DeleteAsync("https://localhost:44341/api/Messages" + "/" + messageId);

        }
    }
}
