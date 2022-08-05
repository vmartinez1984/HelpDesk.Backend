using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.Repository
{
    public class SubcategoryRepository : ISubcategoryRepository
    {
        private readonly IMongoCollection<SubcategoryEntity> _collection;

        public SubcategoryRepository(IOptions<TicketsDbSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<SubcategoryEntity>(
                databaseSettings.Value.SubcategoriesCollection);
        }

        public Task<List<SubcategoryEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SubcategoryEntity> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SubcategoryEntity>> GetByCategoryAsync(string categoryId)
        {
            List<SubcategoryEntity> entities;

            entities = await _collection.Find(x => x.CategoryId == categoryId && x.IsActive == true).ToListAsync();

            return entities;
        }

        public Task UpdateAsync(SubcategoryEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}