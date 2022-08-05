using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly IMongoCollection<StateEntity> _collection;

        public StateRepository(IOptions<TicketsDbSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<StateEntity>(
                databaseSettings.Value.StateCollection);
        }

        public async Task<List<StateEntity>> GetAsync()
        {
            List<StateEntity> entities;

            entities = await _collection.Find(x => x.IsActive == true).ToListAsync();

            return entities;
        }
    }
}