using Microsoft.Extensions.Options;
using MongoDB.Bson;
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

        public async Task<List<TicketEntity>> GetAsync(PagerEntity pager)
        {
            List<TicketEntity> entities;
            FilterDefinition<TicketEntity> filter;

            if (string.IsNullOrEmpty(pager.Search))
                filter = Builders<TicketEntity>.Filter.Where(_ => true);
            else
                filter = Builders<TicketEntity>.Filter
                .Where(x => x.Tipo.ToLower().Contains(pager.Search.ToLower()));

            entities = await _collection.Find(filter)
                .Sort("{MuseoId:1}")
                .Skip((pager.PageCurrent - 1) * pager.RecordsPerPage)
                .Limit(pager.RecordsPerPage)
                .ToListAsync();
            pager.TotalRecordsFiltered = entities.Count();
            pager.TotalRecords = (int)await _collection.CountDocumentsAsync(new BsonDocument());

            return entities;
        }

        public Task UpdateAsync(TicketEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}