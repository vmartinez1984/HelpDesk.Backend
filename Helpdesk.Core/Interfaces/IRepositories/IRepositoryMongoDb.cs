using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Interfaces.IRepositories
{
    public interface IRepositoryMongoDb
    {
        IFormAgencyRepository FormAgency {get;}
    }

    public interface IFormAgencyRepository
    {
        Task<string> AddAsync(FormAgencyEntity formAgencyEntity);

        Task<List<FormAgencyEntity>> GetAsync();

        Task<FormAgencyEntity> GetAsync(string id);

        Task DeleteAsync(string id);
    }
}