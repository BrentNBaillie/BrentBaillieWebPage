using BrentBaillieAPI.Models;

namespace BrentBaillieAPI.Services.Information
{
    public interface IInfoService
    {
        Task<IEnumerable<Info>> GetAllAsync();
        Task<Info> GetById(string id);
        Task CreateAsync(Info info);
        Task UpdateAsync(string id, Info info);
        Task DeleteAsync(string id);
    }
}