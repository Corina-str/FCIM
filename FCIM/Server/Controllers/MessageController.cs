using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FCIM.Server.Data;
using FCIM.Shared;

namespace BiroulSindicalFCIM.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public MessageController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Message>>> GetMessages() 
        {
            var messages = await _applicationDbContext.Messages.ToListAsync();
            return Ok(messages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMessageById(int id)
        {
            var message = _applicationDbContext.Messages
                .FirstOrDefault(p => p.Id == id);
            if (message == null)
            {
                return NotFound("Message not found!");
            }
            return Ok(message);
        }

        [HttpPost]
        public async Task<ActionResult<List<Message>>> Message(Message message)
        {
            _applicationDbContext.Messages.Add(message);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(await _applicationDbContext.Messages.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Message>>> UpdateMessage(Message message, int id)
        {
            var dbMessage = await _applicationDbContext.Messages
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbMessage == null)
            {
                return NotFound("Messages not found!");
            }

            dbMessage.Mesaj = message.Mesaj;

            await _applicationDbContext.SaveChangesAsync();

            return Ok(await _applicationDbContext.Messages.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Message>>> DeleteMessage(int id)
        {
            var dbMessage = await _applicationDbContext.Messages
                .FirstOrDefaultAsync(p => p.Id == id);

            if (dbMessage == null)
            {
                return NotFound("Messagenot found!");
            }

            _applicationDbContext.Messages.Remove(dbMessage);
            await _applicationDbContext.SaveChangesAsync();

            return Ok(await _applicationDbContext.Messages.ToListAsync());
        }
    }
}
