using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoCollection<CategoryEntity> _collection;

        public CategoryRepository(IOptions<TicketsDbSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(
           databaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                databaseSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<CategoryEntity>(
                databaseSettings.Value.CategoriesCollection);
        }

        public async Task UpdateAsync(CategoryEntity entity)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryEntity>> GetAsync()
        {
            List<CategoryEntity> entities;

            entities = await _collection.Find(x => x.IsActive == true).ToListAsync();

            return entities;
        }

        public async Task<CategoryEntity> GetAsync(string id)
        {
            CategoryEntity entity;
            
            entity = await _collection.Find(x => x.Id == id).FirstAsync();

            return entity;
        }
    }
}