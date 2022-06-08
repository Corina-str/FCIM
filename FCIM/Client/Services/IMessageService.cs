using BiroulSindicalFCIM.Shared;
using FCIM.Shared;

namespace BiroulSindicalFCIM.Client.Services
{
    public interface IMessageService
    {
        List<Message> Messages { get; set; }
        Task GetMessages();
        Task<Message> GetMessageById(int id);
        Task CreateMessage(Message message);
        Task UpdateMessage(Message message);
        Task DeleteMessage(int id);
    }
}