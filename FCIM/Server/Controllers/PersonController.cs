using Microsoft.AspNetCore.Mvc;
using BiroulSindicalFCIM.Shared;
using Microsoft.EntityFrameworkCore;
using FCIM.Server.Data;

namespace BiroulSindicalFCIM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public PersonController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPersons() // metoda pentru extragerea datelor despre personane
        {
            var persons = await _applicationDbContext.Persons.ToListAsync();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersonById(int id)
        {
            var person = _applicationDbContext.Persons
                .FirstOrDefault(p => p.Id == id);
            if (person == null)
            {
                return NotFound("Person not found!");
            }
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> CreatePerson(Person person)
        {
            _applicationDbContext.Persons.Add(person);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(await _applicationDbContext.Persons.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person person, int id)
        {
            var dbPerson = await _applicationDbContext.Persons
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbPerson == null)
            {
                return NotFound("Person not found!");
            }

            dbPerson.FirstName = person.FirstName;
            dbPerson.LastName = person.LastName;
            dbPerson.Email = person.Email;
            dbPerson.Status = person.Status;
            dbPerson.MobileNo = person.MobileNo;
            dbPerson.LastCamin = person.LastCamin;
            dbPerson.LastRoom = person.LastRoom;
            dbPerson.FutureCamin = person.FutureCamin;
            dbPerson.FutureRoom = person.FutureRoom;
            dbPerson.IDNP = person.IDNP;
            dbPerson.Comment = person.Comment;

            await _applicationDbContext.SaveChangesAsync();

            return Ok(await _applicationDbContext.Persons.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var dbPerson = await _applicationDbContext.Persons
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbPerson == null)
            {
                return NotFound("Person not found!");
            }

            _applicationDbContext.Persons.Remove(dbPerson);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(await _applicationDbContext.Persons.ToListAsync());
        }
    }
}
