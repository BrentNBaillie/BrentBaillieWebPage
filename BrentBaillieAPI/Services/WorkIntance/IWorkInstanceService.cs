using BrentBaillieAPI.Models;

namespace BrentBaillieAPI.Services.WorkIntance
{
    public interface IWorkInstanceService
    {
        Task<IEnumerable<WorkInstance>> GetAllAsync();
        Task<WorkInstance> GetById(string id);
        Task CreateAsync(WorkInstance workInstance);
        Task UpdateAsync(string id, WorkInstance workInstance);
        Task DeleteAsync(string id);
    }
}