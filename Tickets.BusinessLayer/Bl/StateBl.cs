using AutoMapper;
using Tickets.Core.Dtos;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IBusinessLayer;
using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.BusinessLayer.Bl
{
    public class StateBl : IStateBl
    {
        private IRepositoryTickets _repositoryTickets;
        private IMapper _mapper;

        public StateBl(
            IRepositoryTickets repositoryTickets
            , IMapper mapper
        )
        {
            _repositoryTickets = repositoryTickets;
            _mapper = mapper;
        }

        public async Task<List<StateDto>> GetAsync()
        {
            List<StateEntity> entities;
            List<StateDto> list;

            entities = await _repositoryTickets.State.GetAsync();
            list = _mapper.Map<List<StateDto>>(entities);

            return list;
        }
    }
}