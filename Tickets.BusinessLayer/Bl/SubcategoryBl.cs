using AutoMapper;
using Tickets.Core.Dtos;
using Tickets.Core.Entities;
using Tickets.Core.Interfaces.IBusinessLayer;
using Tickets.Core.Interfaces.IRepositories;

namespace Tickets.BusinessLayer.Bl
{
    public class SubcategoryBl : ISubcategoryBl
    {
        private IRepositoryTickets _repositoryTickets;
        private IMapper _mapper;

        public SubcategoryBl(
            IRepositoryTickets repositoryTickets
            , IMapper mapper
        )
        {
            _repositoryTickets = repositoryTickets;
            _mapper = mapper;
        }

        public async Task<List<SubcategoryDto>> GetAsync()
        {
            List<SubcategoryEntity> entities;
            List<SubcategoryDto> list;

            entities = await _repositoryTickets.Subcategory.GetAsync();
            list = _mapper.Map<List<SubcategoryDto>>(entities);

            return list;
        }

        public async Task<List<SubcategoryDto>> GetByCategoryAsync(string categoryId)
        {
            List<SubcategoryEntity> entities;
            List<SubcategoryDto> list;

            entities = await _repositoryTickets.Subcategory.GetByCategoryAsync(categoryId);
            list = _mapper.Map<List<SubcategoryDto>>(entities);

            return list;
        }

    }
}