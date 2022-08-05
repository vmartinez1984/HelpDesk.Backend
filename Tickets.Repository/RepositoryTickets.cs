using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.Repository
{
    public class RepositoryTickets : IRepositoryTickets
    {
        public RepositoryTickets(
            ITicketRepository ticket,
            ICategoryRepository category,
            ISubcategoryRepository sucategory,
            IStateRepository stateRepository
        )
        {
            this.Ticket = ticket;
            this.Category = category;
            this.Subcategory = sucategory;
            this.State = stateRepository;
        }
        public ITicketRepository Ticket { get; }

        public ICategoryRepository Category { get; }

        public ISubcategoryRepository Subcategory { get; }

        public IStateRepository State {get;}
    }

}