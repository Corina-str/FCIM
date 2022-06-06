using BiroulSindicalFCIM.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BiroulSindicalFCIM.Client.Services
{
    public class EduCardService : IEduCardService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public EduCardService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<EduCard> EduCards { get; set; }

        public async Task CreateEduCard(EduCard educard)
        {
            var result = await _httpClient.PostAsJsonAsync("api/educard", educard);
            SetEduCards(result);
        }

        public async Task DeleteEduCard(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/educard/{id}");
            SetEduCards(result);
        }

        public async Task<EduCard> GetEduCardById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<EduCard>($"api/educard/{id}");
            if (result != null)
                return result;
            throw new Exception("EduCard not found!");
        }

        public async Task GetEduCards()
        {
            var result = await _httpClient.GetFromJsonAsync<List<EduCard>>("api/educard");
            if (result != null)
            {
                EduCards = result;
            }
        }

        public async Task UpdateEduCard(EduCard educard)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/educard/{educard.Id}", educard);
            SetEduCards(result);
        }

        private async Task SetEduCards(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<EduCard>>();
            EduCards = response;
            _navigationManager.NavigateTo("educards");
        }
    }
}
