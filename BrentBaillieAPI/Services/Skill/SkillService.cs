using BrentBaillieAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BrentBaillieAPI.Services.Skills
{
    public class SkillService : ISkillService
    {
        private readonly IMongoCollection<Skill> _skillCollect;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public SkillService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _skillCollect = mongoDatabase.GetCollection<Skill>(dbSettings.Value.SkillCollectionName);
        }

        public async Task<IEnumerable<Skill>> GetAllAsync() =>
               await _skillCollect.Find(_ => true).ToListAsync();

        public async Task<Skill> GetById(string id) =>
            await _skillCollect.Find(a => a._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Skill skill) =>
            await _skillCollect.InsertOneAsync(skill);

        public async Task UpdateAsync(string id, Skill skill) =>
            await _skillCollect.ReplaceOneAsync(a => a._id == id, skill);

        public async Task DeleteAsync(string id) =>
            await _skillCollect.DeleteOneAsync(a => a._id == id);
    }
}
