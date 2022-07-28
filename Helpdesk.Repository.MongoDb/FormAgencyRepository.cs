using Helpdesk.Core.Entities;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.Repository.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Helpdesk.Repository.MongoDb;
public class FormAgencyRepository : IFormAgencyRepository
{
    private readonly IMongoCollection<FormAgencyEntity> _collection;

    public FormAgencyRepository(IOptions<DatabaseSettings> databaseSettings)
    {
        var mongoClient = new MongoClient(
       databaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            databaseSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<FormAgencyEntity>(
            databaseSettings.Value.FormAgencyCollectionName);
    }

    public async Task<string> AddAsync(FormAgencyEntity entity)
    {
        await _collection.InsertOneAsync(entity);

        return entity.Id;
    }

    public async Task DeleteAsync(string id)
    {
        FormAgencyEntity entity;

        entity = await GetAsync(id);
        entity.IsActive = false;

        await _collection.ReplaceOneAsync(x => x.Id == entity.Id, entity);
    }

    public async Task<List<FormAgencyEntity>> GetAsync()
    {
        List<FormAgencyEntity> entities;

        entities = await _collection.Find(x => x.IsActive == true).ToListAsync();

        return entities;
    }

    public async Task<FormAgencyEntity> GetAsync(string id)
    {
        FormAgencyEntity entity;

        entity = await _collection.Find(x => x.Id == id && x.IsActive == true).FirstAsync();

        return entity;
    }
}