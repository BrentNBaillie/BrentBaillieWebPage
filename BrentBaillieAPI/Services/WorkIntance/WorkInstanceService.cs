using BrentBaillieAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BrentBaillieAPI.Services.WorkIntance
{
    public class WorkInstanceService : IWorkInstanceService
    {
        private readonly IMongoCollection<WorkInstance> _workInstanceCollect;
        private readonly IOptions<DatabaseSettings> _dbSettings;

        public WorkInstanceService(IOptions<DatabaseSettings> dbSettings)
        {
            _dbSettings = dbSettings;
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
            _workInstanceCollect = mongoDatabase.GetCollection<WorkInstance>(dbSettings.Value.WorksInstanceCollectionName);
        }

        public async Task<IEnumerable<WorkInstance>> GetAllAsync() =>
               await _workInstanceCollect.Find(_ => true).ToListAsync();

        public async Task<WorkInstance> GetById(string id) =>
            await _workInstanceCollect.Find(a => a._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(WorkInstance workInstance) =>
            await _workInstanceCollect.InsertOneAsync(workInstance);

        public async Task UpdateAsync(string id, WorkInstance workInstance) =>
            await _workInstanceCollect.ReplaceOneAsync(a => a._id == id, workInstance);

        public async Task DeleteAsync(string id) =>
            await _workInstanceCollect.DeleteOneAsync(a => a._id == id);
    }
}
