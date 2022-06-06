using Microsoft.AspNetCore.Mvc;
using BiroulSindicalFCIM.Shared;
using Microsoft.EntityFrameworkCore;
using FCIM.Server.Data;

namespace BiroulSindicalFCIM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EduCardController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EduCardController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<EduCard>>> GetEduCards() // metoda pentru extragerea datelor despre personane
        {
            var educards = await _applicationDbContext.EduCards.ToListAsync();
            return Ok(educards);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEduCardById(int id)
        {
            var educard = _applicationDbContext.EduCards
                .FirstOrDefault(p => p.Id == id);
            if (educard == null)
            {
                return NotFound("EduCard not found!");
            }
            return Ok(educard);
        }

        [HttpPost]
        public async Task<ActionResult<List<EduCard>>> CreateEduCard(EduCard educard)
        {
            _applicationDbContext.EduCards.Add(educard);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(await _applicationDbContext.EduCards.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<EduCard>>> UpdateEduCard(EduCard educard, int id)
        {
            var dbEduCard = await _applicationDbContext.EduCards
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbEduCard == null)
            {
                return NotFound("EduCards not found!");
            }

            dbEduCard.FirstName = educard.FirstName;
            dbEduCard.LastName = educard.LastName;
            dbEduCard.Email = educard.Email;
            dbEduCard.MobileNo = educard.MobileNo;
            dbEduCard.Grupa = educard.Grupa;

            await _applicationDbContext.SaveChangesAsync();

            return Ok(await _applicationDbContext.EduCards.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<EduCard>>> DeleteEduCard(int id)
        {
            var dbEduCard = await _applicationDbContext.EduCards
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbEduCard == null)
            {
                return NotFound("EduCardnot found!");
            }

            _applicationDbContext.EduCards.Remove(dbEduCard);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(await _applicationDbContext.EduCards.ToListAsync());
        }
    }
}
