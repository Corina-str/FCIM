using BiroulSindicalFCIM.Shared;

namespace BiroulSindicalFCIM.Client.Services
{
    public interface IEduCardService
    {
        List<EduCard> EduCards { get; set; }
        Task GetEduCards();
        Task<EduCard> GetEduCardById(int id);
        Task CreateEduCard(EduCard educard);
        Task UpdateEduCard(EduCard educard);
        Task DeleteEduCard(int id);
    }
}
