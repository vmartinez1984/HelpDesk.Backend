using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.Repository
{
    public class TicketRepository : ITicketRepository
    {
        public Task<List<TicketEntity>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TicketEntity> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(TicketEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}