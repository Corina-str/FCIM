using BiroulSindicalFCIM.Shared;

namespace BiroulSindicalFCIM.Client.Services
{
    public interface IPersonService
    {
        List<Person> Persons { get; set; }
        Task GetPersons();
        Task<Person> GetPersonById(int id);
        Task CreatePerson(Person person);
        Task UpdatePerson(Person person);
        Task DeletePerson(int id);
    }
}
