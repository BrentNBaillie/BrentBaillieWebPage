using BrentBaillieAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BrentBaillieAPI.Services.Information
{
    public class InfoService : IInfoService
    {
        private readonly IMongoCollection<Info> _infoCollect;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public InfoService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _infoCollect = mongoDatabase.GetCollection<Info>(dbSettings.Value.InfoCollectionName);
        }

        public async Task<IEnumerable<Info>> GetAllAsync() =>
               await _infoCollect.Find(_ => true).ToListAsync();

        public async Task<Info> GetById(string id) =>
            await _infoCollect.Find(a => a._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Info info) =>
            await _infoCollect.InsertOneAsync(info);

        public async Task UpdateAsync(string id, Info info) =>
            await _infoCollect.ReplaceOneAsync(a => a._id == id, info);

        public async Task DeleteAsync(string id) =>
            await _infoCollect.DeleteOneAsync(a => a._id == id);
    }
}
