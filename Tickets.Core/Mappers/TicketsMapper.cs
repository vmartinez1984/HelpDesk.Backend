using AutoMapper;
using Tickets.Core.Dtos;
using Tickets.Core.Entities;

namespace Tickets.Core.Mappers
{
    public class TicketsMapper: Profile
    {
        public TicketsMapper()
        {
            CreateMap<CategoryEntity, CategoryDto>();
            
            CreateMap<SubcategoryEntity, SubcategoryDto>();

            CreateMap<StateEntity, StateDto>();

            CreateMap<TicketDtoIn, TicketEntity>();
        }
    }
}