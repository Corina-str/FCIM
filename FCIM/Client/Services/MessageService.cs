using BiroulSindicalFCIM.Shared;
using FCIM.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BiroulSindicalFCIM.Client.Services
{
    public class MessageService : IMessageService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public MessageService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Message> Messages { get; set; }

        public async Task CreateMessage(Message message)
        {
            var result = await _httpClient.PostAsJsonAsync("api/message", message);
            SetMessages(result);
        }

        public async Task DeleteMessage(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/message/{id}");
            SetMessages(result);
        }

        public async Task<Message> GetMessageById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Message>($"api/message/{id}");
            if (result != null)
                return result;
            throw new Exception("Message not found!");
        }

        public async Task GetMessages()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Message>>("api/message");
            if (result != null)
            {
                Messages = result;
            }
        }

        public async Task UpdateMessage(Message message)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/message/{message.Id}", message);
            SetMessages(result);
        }

        private async Task SetMessages(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Message>>();
            Messages = response;
            _navigationManager.NavigateTo("messages");
        }
    }
}
