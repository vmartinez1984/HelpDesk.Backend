using Tickets.Core.Entities;

namespace Tickets.Core.Interfaces.IRepositories
{
    public interface IRepositoryTickets
    {
        ITicketRepository Ticket { get; }

        ICategoryRepository Category { get; }

        ISubcategoryRepository Subcategory { get; }
    }

    public interface ITicketRepository
    {
        Task<List<TicketEntity>> GetAsync();

        Task<TicketEntity> GetAsync(string id);

        Task UpdateAsync(TicketEntity entity);
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

        Task UpdateAsync(SubcategoryEntity entity);
    }
}