using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.Repository
{
    public class RepositoryTickets : IRepositoryTickets
    {
        public RepositoryTickets(
            ITicketRepository ticket,
            ICategoryRepository category,
            ISubcategoryRepository sucategory
        )
        {
            this.Ticket = ticket;
            this.Category = category;
            this.Subcategory = sucategory;
        }
        public ITicketRepository Ticket { get; }

        public ICategoryRepository Category { get; }

        public ISubcategoryRepository Subcategory { get; }
    }

}