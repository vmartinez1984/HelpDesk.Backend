using AutoMapper;
using Helpdesk.Core.Dtos;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Entities;

namespace Helpdesk.Core.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserEntity, UserDtoOut>().ReverseMap();
            CreateMap<UserEntity, UserDtoIn>().ReverseMap();
        }
    }

    public class ProjectMapper : Profile
    {
        public ProjectMapper()
        {
            CreateMap<ProjectEntity, ProjectDtoOut>().ReverseMap();
            CreateMap<ProjectEntity, ProjectDtoIn>().ReverseMap();
        }
    }

    public class AgencyTypeMapper : Profile
    {
        public AgencyTypeMapper()
        {
            CreateMap<AgencyTypeEntity, AgencyTypeDtoOut>().ReverseMap();
            CreateMap<AgencyTypeEntity, AgencyTypeDtoIn>().ReverseMap();
        }
    }

    public class AgencyMapper : Profile
    {
        public AgencyMapper()
        {
            CreateMap<AgencyEntity, AgencyDtoOut>().ReverseMap();
            CreateMap<AgencyEntity, AgencyDtoIn>().ReverseMap();
        }
    }

    public class PersonSearchMapper : Profile
    {
        public PersonSearchMapper()
        {
            CreateMap<PersonSearchDtonIn, PersonSearchEntity>().ReverseMap();
            CreateMap<PersonSearchEntity, PersonSearchDto>().ReverseMap();
        }
    }
    public class PersonMapper : Profile
    {
        public PersonMapper()
        {
            CreateMap<PersonEntity, PersonDtoOut>().ReverseMap();
            CreateMap<PersonEntity, PersonDtoIn>().ReverseMap();
        }
    }

    public class ZipCodeMapper : Profile
    {
        public ZipCodeMapper()
        {
            CreateMap<ZipCodeEntity, ZipCodeDto>().ReverseMap();
        }
    }

    public class AgencySearchInMapper : Profile
    {
        public AgencySearchInMapper()
        {
            CreateMap<AgencySearchDtoIn, AgencySearchEntity>().ReverseMap();
        }
    }

    public class AgencySearchOutMapper : Profile
    {
        public AgencySearchOutMapper()
        {
            CreateMap<AgencySearchDtoOut, AgencySearchEntity>().ReverseMap();
        }
    }

    public class AgencySearchResultOutMapper : Profile
    {
        public AgencySearchResultOutMapper()
        {
            CreateMap<AgencyListDtoOut, AgencySearchEntityOut>().ReverseMap();
        }
    }

    public class ImplementsMapper : Profile
    {
        public ImplementsMapper()
        {
            CreateMap<PersonSearchEntity, PersonSearchDtonIn>();
            CreateMap<PersonPagerEntity, PersonPagerDtoOut>();

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
        }
    }
}