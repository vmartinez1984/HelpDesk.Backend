using Tickets.Core.Interfaces.IBusinessLayer;
using Tickets.Core.Dtos;

namespace Tickets.BusinessLayer.Bl
{
    public class TicketBl : ITicketBl
    {
        public Task<List<TicketDto>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> AddAsync(TicketDtoIn item)
        {
            throw new NotImplementedException();
        }
    }
}