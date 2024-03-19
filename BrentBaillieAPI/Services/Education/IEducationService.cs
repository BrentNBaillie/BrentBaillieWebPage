using BrentBaillieAPI.Models;

namespace BrentBaillieAPI.Services.Educations
{
    public interface IEducationService
    {
        Task<IEnumerable<Education>> GetAllAsync();
        Task<Education> GetById(string id);
        Task CreateAsync(Education education);
        Task UpdateAsync(string id, Education education);
        Task DeleteAsync(string id);
    }
}
