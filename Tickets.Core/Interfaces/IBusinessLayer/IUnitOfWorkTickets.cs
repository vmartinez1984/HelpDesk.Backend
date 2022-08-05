using Tickets.Core.Dtos;

namespace Tickets.Core.Interfaces.IBusinessLayer
{
    public interface IUnitOfWorkTickets
    {
        ITicketBl Ticket { get; }
        
        ICategoryBl Category { get; }

        ISubcategoryBl Subcategory { get; }
        IStateBl State { get; }
    }

    public interface ITicketBl
    {
        Task<List<TicketDto>> GetAsync();

        Task<string> AddAsync(TicketDtoIn item);
    }

    public interface ICategoryBl
    {
        Task<List<CategoryDto>> GetAsync();
    }
    
    public interface IStateBl
    {
        Task<List<StateDto>> GetAsync();
    }

    public interface ISubcategoryBl
    {
        Task<List<SubcategoryDto>> GetAsync();
        
        Task<List<SubcategoryDto>> GetByCategoryAsync(string categoryId);
    }
}