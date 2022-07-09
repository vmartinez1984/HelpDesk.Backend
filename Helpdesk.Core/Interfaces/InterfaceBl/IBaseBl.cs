using System.Collections;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;

namespace Helpdesk.Core.Interfaces.InterfaceBl
{
    public interface IBaseBl<T, U> where T : class
    {
        Task<int> AddAsync(T item);
        Task DeleteAsync(int id);
        Task<U> GetAsync(int id);
        Task<List<U>> GetAsync();
        Task UpdateAsync(T item, int id);
    }

    public interface IBaseBl01<T, U> where T : class
    {
        Task<int> AddAsync(T item);
        Task DeleteAsync(int id);
        Task<U> GetAsync(int id);
        Task UpdateAsync(T item, int id);
    }

    public interface IBase02Bl<T, U> where T : class
    {
        Task<int> AddAsync(T item);
        Task DeleteAsync(int id);
        Task<U> GetAsync(int id);
        Task UpdateAsync(T item, int id);
    }

    public interface IUserBl : IBaseBl01<UserDtoIn, UserDtoOut>
    {
        Task<UserDtoOut> Login(LoginDto login);

        Task<List<UserDtoOut>> GetAsync(int? projectId, int? agencyId);

        Task<bool> Exists(string email);
    }

    public interface IProjectBl : IBaseBl<ProjectDtoIn, ProjectDtoOut> 
    { 
         Task DeleteAsync(ProjectDeleteDtoIn item);
    }

    public interface IAgencyTypeBl : IBaseBl<AgencyTypeDtoIn, AgencyTypeDtoOut>
    {

    }

    public interface IAgencyBl : IBase02Bl<AgencyDtoIn, AgencyDtoOut>
    {
        Task<AgencyListDtoOut> GetAsync(AgencySearchDtoIn agencySearchDtoIn);
    }

    public interface IPersonBl : IBase02Bl<PersonDtoIn, PersonDtoOut>
    {
        Task<PersonPagerDtoOut> GetAsync(PersonSearchDtonIn personSearch);
    }

    public interface IZipCodeBl
    {
        Task<List<ZipCodeDto>> GetAsync(string zipCode);
    }

    public interface IRoleBl
    {
        Task<List<RoleDto>> GetAsync();
    }
}