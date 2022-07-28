using Helpdesk.Core.Dtos;
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

    public interface IResponsiveBl
    {
        Task<bool> ExistsWithoutSendAsync();
        Task<ResponsiveDto> GetWithoutSendAsync();

        void SendResponsive(string documentId);

        void SendResponsive(string email, string documentId);
        void UpdateDateSend(int id);
    }

    public interface IFormAgencyBl
    {
        Task<int> AddAsync(FormAgencyDtoIn item);
        Task<List<FormAgencyDto>> GetAsync();
        Task<FormAgencyDto> GetAsync(string id);
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

        Task<UserListDtoOut> GetAsync(UserSearchDtoIn userSearch);

        Task<bool> Exists(string email, int id);

        Task UpdateAsync(UserDtoOut item);
    }

    public interface IProjectBl : IBaseBl<ProjectDtoIn, ProjectDtoOut>
    {
        Task DeleteAsync(ProjectDeleteDtoIn item);
    }

    public interface IAgencyTypeBl : IBaseBl<AgencyTypeDtoIn, AgencyTypeDtoOut> { }

    public interface IAgencyBl : IBase02Bl<AgencyDtoIn, AgencyDtoOut>
    {
        Task<AgencyListDtoOut> GetAsync(AgencySearchDtoIn agencySearchDtoIn);
        Task<List<AgencyDtoOut>> GetByProjectIdAsync(int projectId);
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

    public interface IDeviceBl
    {
        Task<int> AddAsync(DeviceDtoIn item);

        Task<DeviceListDto> GetAsync(DeviceSearchDtoIn deviceSearch);

        Task<DeviceDto> GetAsync(int id);
    }
}