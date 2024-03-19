using BrentBaillieAPI.Models;

namespace BrentBaillieAPI.Services.Skills
{
    public interface ISkillService
    {
        Task<IEnumerable<Skill>> GetAllAsync();
        Task<Skill> GetById(string id);
        Task CreateAsync(Skill skill);
        Task UpdateAsync(string id, Skill skill);
        Task DeleteAsync(string id);
    }
}