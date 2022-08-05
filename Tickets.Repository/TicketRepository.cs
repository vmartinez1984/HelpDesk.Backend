using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.Repository
{
    public class TicketRepository : ITicketRepository
    {
         private readonly IMongoCollection<TicketEntity> _collection;

        public TicketRepository(IOptions<TicketsDbSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<TicketEntity>(
                databaseSettings.Value.TicketsCollection);
        }

        public async Task<string> AddAsync(TicketEntity entity)
        {
            await _collection.InsertOneAsync(entity);

            return entity.Id;
        }

        public Task<List<TicketEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TicketEntity> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TicketEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}