using AutoMapper;
using Helpdesk.Core.Dtos;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;
using Tickets.Core.Dtos;

namespace Helpdesk.Core.Mappers
{
    public class ImplementsMapper : Profile
    {
        public ImplementsMapper()
        {
            CreateMap<UserEntity, UserDtoOut>().ReverseMap();
            CreateMap<UserEntity, UserDto>();
            CreateMap<UserEntity, UserDtoIn>().ReverseMap();

            CreateMap<ProjectEntity, ProjectDtoOut>().ReverseMap();
            CreateMap<ProjectEntity, ProjectDtoIn>().ReverseMap();

            CreateMap<AgencyTypeEntity, AgencyTypeDtoOut>().ReverseMap();
            CreateMap<AgencyTypeEntity, AgencyTypeDtoIn>().ReverseMap();

            CreateMap<AgencyEntity, AgencyDtoOut>().ReverseMap();
            CreateMap<AgencyEntity, AgencyDtoIn>().ReverseMap();

            CreateMap<PersonEntity, PersonDtoOut>().ReverseMap();
            CreateMap<PersonEntity, PersonDtoIn>().ReverseMap();

            CreateMap<ZipCodeEntity, ZipCodeDto>().ReverseMap();

            CreateMap<RoleEntity, RoleDto>();

            CreateMap<PagerDto, PagerEntity>().ReverseMap();
            CreateMap<PagerDtoIn, PagerEntity>().ReverseMap();

            CreateMap<UserSearchDtoIn, UserSearchEntity>();
            CreateMap<UserSearchEntity, UserListDtoOut>();
            CreateMap<UserSearchEntity, UserSearchDtoIn>();
            CreateMap<PagerEntity, UserSearchEntity>();

            CreateMap<DeviceSearchDtoIn, DeviceSearchEntity>();
            CreateMap<DeviceSearchEntity, DeviceListDto>();
            CreateMap<DeviceDtoIn, DeviceEntity>();
            CreateMap<DeviceEntity, DeviceDto>();

            CreateMap<FormAgencyDtoIn, AgencyEntity>();
            CreateMap<FormAgencyDtoIn, FormAgencyEntity>();

            CreateMap<ResponsiveEntity, ResponsiveDto>();
            CreateMap<FormAgencyEntity, FormAgencyDto>();

            CreateMap<SearchDtoIn, PagerEntity>();
            
            CreateMap<Tickets.Core.Entities.TicketEntity, TicketDto>();
        }
    }
}