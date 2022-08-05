using Tickets.Core.Interfaces.IBusinessLayer;

namespace Tickets.BusinessLayer.Bl
{
    public class UnitOfWorkTickets : IUnitOfWorkTickets
    {
        public UnitOfWorkTickets(
            ITicketBl ticket,
            ICategory category
        )
        {
            this.Ticket = ticket;
            this.Category = category;
        }

        public ITicketBl Ticket { get; }

        public ICategory Category {get;}
    }
}