using Tickets.Core.Entities;

namespace Tickets.Core.Interfaces.IRepositories
{
    public interface IRepositoryTickets
    {
        ITicketRepository Ticket { get; }

        ICategoryRepository Category { get; }

        ISubcategoryRepository Subcategory { get; }
        IStateRepository State { get; }
    }

    public interface IStateRepository
    {
        Task<List<StateEntity>> GetAsync();
    }

    public interface ITicketRepository
    {
        Task<string> AddAsync(TicketEntity entity);

        Task<TicketEntity> GetAsync(string id);

        Task UpdateAsync(TicketEntity entity);

        Task<List<TicketEntity>> GetAsync(PagerEntity pagerEntity);
    }

    public interface ICategoryRepository
    {
        Task<List<CategoryEntity>> GetAsync();

        Task<CategoryEntity> GetAsync(string id);

        Task UpdateAsync(CategoryEntity entity);
    }

    public interface ISubcategoryRepository
    {
        Task<List<SubcategoryEntity>> GetAsync();

        Task<SubcategoryEntity> GetAsync(string id);
        Task<List<SubcategoryEntity>> GetByCategoryAsync(string categoryId);
        Task UpdateAsync(SubcategoryEntity entity);
    }
}