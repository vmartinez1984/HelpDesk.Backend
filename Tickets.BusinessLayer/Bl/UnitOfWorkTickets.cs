using Tickets.Core.Interfaces.IBusinessLayer;

namespace Tickets.BusinessLayer.Bl
{
    public class UnitOfWorkTickets : IUnitOfWorkTickets
    {
        public UnitOfWorkTickets(
            ITicketBl ticket
            , ICategoryBl category
            , ISubcategoryBl subcategoryBl
            , IStateBl stateBl
        )
        {
            this.Ticket = ticket;
            this.Category = category;
            this.Subcategory = subcategoryBl;
            this.State = stateBl;
        }

        public ITicketBl Ticket { get; }

        public ICategoryBl Category { get; }

        public ISubcategoryBl Subcategory { get; }

        public IStateBl State {get;}
    }
}