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
        IRoleRepository Role { get; }
        IDeviceRepository Device { get; }
        IDeviceStateRepository DeviceState { get; }
        IResponsiveRepository Resposive { get; }
    }

    public interface IResponsiveRepository : IBaseARepository<ResponsiveEntity>
    {
        Task<bool> ExistsWithoutSendAsync();

        Task<ResponsiveEntity> GetWithoutSendAsync();

        Task<ResponsiveEntity> GetAsync(string documentId);

        Task<List<ResponsiveEntity>> GetAsync(PagerEntity search);
    }

    public interface IDeviceStateRepository
    {
        Task<List<DeviceStateEntity>> GetAsync();
    }

    public interface IBaseRepository<T> where T : class
    {
        Task<int> AddAsync(T entity);

        Task DeleteAsync(int id, int userId);

        Task<T> GetAsync(int id);

        Task UpdateAsync(T entity);
    }

    public interface IBaseARepository<T> where T : class
    {
        Task<int> AddAsync(T entity);

        Task DeleteAsync(int id);

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

    public interface IDeviceRepository
    {
        Task<int> AddAsync(DeviceEntity entity);

        Task<DeviceEntity> GetAsync(int id);

        Task UpdateAsync(DeviceEntity entity);

        Task<List<DeviceEntity>> GetAsync(DeviceSearchEntity search);
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

        Task<List<UserEntity>> GetAsync(UserSearchEntity userSearch);

        Task<bool> ExistsAsync(string email, int userId);

        Task<string> GetNameAsync(int userId);
    }

    public interface IProjectRepository : IBaseRepositoryCatalog<ProjectEntity>
    {
        Task DeleteAsync(int id, string reason);
    }

    public interface IAgencyTypeRepository : IBaseRepositoryCatalog<AgencyTypeEntity> { }

    public interface IAgencyRepository : IBaseRepository02<AgencyEntity>
    {
        Task<List<AgencyEntity>> GetAsync(PagerEntity searchEntity);
        
        Task<List<AgencyEntity>> GetByProjectIdAsync(int projectId);
    }

    public interface IPersonRepository : IBaseRepository02<PersonEntity>
    {
        Task<List<PersonEntity>> GetAsync(PagerEntity search);
    }

    public interface IRoleRepository
    {
        Task<List<RoleEntity>> GetAsync();
    }

}