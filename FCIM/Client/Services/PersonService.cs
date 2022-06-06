using BiroulSindicalFCIM.Shared;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace BiroulSindicalFCIM.Client.Services
{
    public class PersonService : IPersonService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public PersonService(HttpClient httpClient, NavigationManager navigationManager)
        {
            _httpClient = httpClient;
            _navigationManager = navigationManager;
        }

        public List<Person> Persons { get; set; }

        public async Task CreatePerson(Person person)
        {
            var result = await _httpClient.PostAsJsonAsync("api/person", person);
            SetPersons(result);
        }

        public async Task DeletePerson(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/person/{id}");
            SetPersons(result);
        }

        public async Task<Person> GetPersonById(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<Person>($"api/person/{id}");
            if (result != null)
                return result;
            throw new Exception("Person not found!");
        }

        public async Task GetPersons()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Person>>("api/person");
            if (result != null)
            {
                Persons = result;
            }
        }

        public async Task UpdatePerson(Person person)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/person/{person.Id}", person);
            SetPersons(result);
        }

        private async Task SetPersons(HttpResponseMessage result)
        {
            var response = await result.Content.ReadFromJsonAsync<List<Person>>();
            Persons = response;
            _navigationManager.NavigateTo("persons");
        }
    }
}
