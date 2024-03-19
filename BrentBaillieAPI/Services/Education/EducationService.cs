using BrentBaillieAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BrentBaillieAPI.Services.Educations
{
    public class EducationService : IEducationService
    {
        private readonly IMongoCollection<Education> _educationCollect;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public EducationService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _educationCollect = mongoDatabase.GetCollection<Education>(dbSettings.Value.EducationCollectionName);
        }

        public async Task<IEnumerable<Education>> GetAllAsync() =>
               await _educationCollect.Find(_ => true).ToListAsync();

        public async Task<Education> GetById(string id) =>
            await _educationCollect.Find(a => a._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Education education) =>
            await _educationCollect.InsertOneAsync(education);

        public async Task UpdateAsync(string id, Education education) =>
            await _educationCollect.ReplaceOneAsync(a => a._id == id, education);

        public async Task DeleteAsync(string id) =>
            await _educationCollect.DeleteOneAsync(a => a._id == id);
    }
}
