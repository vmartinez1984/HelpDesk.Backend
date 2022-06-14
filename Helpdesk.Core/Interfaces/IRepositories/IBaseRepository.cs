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

        Task<List<T>> GetAsync();

        Task<T> GetAsync(int id);

        Task UpdateAsync(T entity);
    }

    public interface IBaseRepository02<T> where T : class
    {
        Task<int> AddAsync(T entity);

        Task DeleteAsync(int id, int userId);

        Task<T> GetAsync(int id);

        Task UpdateAsync(T entity);
    }

    public interface IUserRepository : IBaseRepository<UserEntity> { }

    public interface IProjectRepository : IBaseRepository<ProjectEntity> { }

    public interface IAgencyTypeRepository : IBaseRepository<AgencyTypeEntity> { }

    public interface IAgencyRepository : IBaseRepository02<AgencyEntity>
    {
        Task<List<AgencyEntity>> GetListAsync(int projectId);
    }

    public interface IPersonRepository : IBaseRepository02<PersonEntity>
    {
        Task<List<PersonEntity>> GetListByAgencyId(int agencyId);
        Task<List<PersonEntity>> GetListByProjecId(int projectId);
    }
}