using Tickets.Core.Dtos;

namespace Tickets.Core.Interfaces.IBusinessLayer
{
    public interface IUnitOfWorkTickets
    {
        ITicketBl Ticket { get; }
        ICategory Category { get; }
    }

    public interface ITicketBl
    {
        Task<List<TicketDto>> GetAsync();

        Task<string> AddAsync(TicketDtoIn item);
    }

    public interface ICategory
    {
        Task<List<CategoryDto>> GetAsync();
    }

    public interface ISubcategory
    {
        Task<List<SubcategoryDto>> GetAsync();
    }
}