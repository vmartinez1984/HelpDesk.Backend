using AutoMapper;
using Tickets.Core.Dtos;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IBusinessLayer;
using Tickets.Core.Interfaces.IRepositories;

namespace Helpdesk.BusinessLayer.Bl
{
    public class CategoryBl : ICategoryBl
    {
        private IRepositoryTickets _repositoryTickets;
        private IMapper _mapper;

        public CategoryBl(
            IRepositoryTickets repositoryTickets
            , IMapper mapper
        )
        {
            _repositoryTickets = repositoryTickets;
            _mapper = mapper;
        }

        public async Task<List<CategoryDto>> GetAsync()
        {
            List<CategoryEntity> entities;
            List<CategoryDto> list;

            entities = await _repositoryTickets.Category.GetAsync();
            list = _mapper.Map<List<CategoryDto>>(entities);

            return list;
        }
    }
}