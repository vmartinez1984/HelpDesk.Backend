using Tickets.Core.Interfaces.IBusinessLayer;
using Tickets.Core.Dtos;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IRepositories;
using AutoMapper;

namespace Tickets.BusinessLayer.Bl
{
    public class TicketBl : ITicketBl
    {
        private IRepositoryTickets _repositoryTickets;
        private IMapper _mapper;

        public TicketBl(
            IRepositoryTickets repositoryTickets
            , IMapper mapper
        )
        {
            _repositoryTickets = repositoryTickets;
            _mapper = mapper;
        }

        public Task<List<TicketDto>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<string> AddAsync(TicketDtoIn item)
        {
            TicketEntity entity;

            entity = _mapper.Map<TicketEntity>(item);
            await _repositoryTickets.Ticket.AddAsync(entity);

            return entity.Id;
        }
    }
}