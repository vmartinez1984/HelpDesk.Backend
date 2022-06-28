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
    }

    public interface IProjectBl : IBaseBl<ProjectDtoIn, ProjectDtoOut> { }

    public interface IAgencyTypeBl : IBaseBl<AgencyTypeDtoIn, AgencyTypeDtoOut>
    {

    }

    public interface IAgencyBl : IBase02Bl<AgencyDtoIn, AgencyDtoOut>
    {
        Task<List<AgencyDtoOut>> GetListAsync(int? projectId);
    }

    public interface IPersonBl : IBase02Bl<PersonDtoIn, PersonDtoOut>
    {
        Task<List<PersonDtoOut>> GetAsync(int? projectId, int? agencyId);
    }

    public interface IZipCodeBl
    {
        Task<List<ZipCodeDto>> GetAsync(string zipCode);
    }
}