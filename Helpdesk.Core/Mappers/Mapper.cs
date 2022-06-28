using AutoMapper;
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

    public class AgencySearchMapper : Profile
    {
        public AgencySearchMapper()
        {
            CreateMap<AgencySearchDtoIn, AgencySearchEntity>().ReverseMap();
        }
    }
}