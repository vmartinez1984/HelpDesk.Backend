using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Interfaces.IRepositories
{
    public interface IRepository
    {
        IUserRepository User { get; }
        IProjectRepository Project { get; }
        IAgencyTypeRepository AgencyType { get; }
        IAgencyRepository Agency { get; }
        IPersonRepository Person { get; }
    }

    public interface IBaseRepository<T> where T : class
    {
        Task<int> AddAsync(T entity);

        Task DeleteAsync(int id, int userId);

        Task<T> GetAsync(int id);

        Task UpdateAsync(T entity);
    }

    public interface IBaseRepositoryCatalog<T> where T : class
    {
        Task<int> AddAsync(T entity);

        Task DeleteAsync(int id, int userId);

        Task<List<T>> GetAsync();

        Task<T> GetAsync(int id);

        Task UpdateAsync(T entity);
    }

    public interface IDeviceRepository : IBaseRepository02<DeviceEntity>
    {

    }

    public interface IBaseRepository02<T> where T : class
    {
        Task<int> AddAsync(T entity);

        Task DeleteAsync(int id, int userId);

        Task<T> GetAsync(int id);

        Task UpdateAsync(T entity);
    }

    public interface IUserRepository : IBaseRepository<UserEntity>
    {
        Task<UserEntity> GetAsync(string userName);

        Task<List<UserEntity>> GetAsync(int? projectId, int? agencyId);
    }

    public interface IProjectRepository : IBaseRepositoryCatalog<ProjectEntity> { }

    public interface IAgencyTypeRepository : IBaseRepositoryCatalog<AgencyTypeEntity> { }

    public interface IAgencyRepository : IBaseRepository02<AgencyEntity>
    {
        Task<AgencySearchEntityOut> GetAsync(AgencySearchEntity agencySearchEntity);
    }

    public interface IPersonRepository : IBaseRepository02<PersonEntity>
    {
        Task<PersonPagerEntity> SearchAsync(PersonSearchEntity search);
    }
}