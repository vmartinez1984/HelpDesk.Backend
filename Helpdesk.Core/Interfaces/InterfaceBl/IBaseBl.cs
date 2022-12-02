using Helpdesk.Core.Dtos;
using Helpdesk.Core.Dtos.Inputs;
using Helpdesk.Core.Dtos.Outputs;
using Tickets.Core.Dtos;

namespace Helpdesk.Core.Interfaces.InterfaceBl
{
    public interface IBaseBl<T, U> where T : class
    {
        Task<int> AddAsync(T item);
        Task DeleteAsync(int id);
        Task<U> GetAsync(int id);
        //Task<List<U>> GetAsync();
        Task UpdateAsync(T item, int id);
    }

    public interface IResponsiveBl
    {
        Task<bool> ExistsWithoutSendAsync();

        Task<ResponsiveDto> GetWithoutSendAsync();

        void SendResponsive(string documentId);

        void SendResponsive(string email, string documentId);

        void UpdateDateSend(int id);

        Task<ResponsivePagerDtoOut> GetAsync(SearchDtoIn searchDtonIn);
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

        Task<PagerDtoOut> GetAsync(SearchDtoIn userSearch);

        Task<bool> Exists(string email, int id);
        
        Task<bool> Exists(string email);

        Task UpdateAsync(UserDtoOut item);        
    }

    public interface IProjectBl : IBaseBl<ProjectDtoIn, ProjectDtoOut>
    {
        Task DeleteAsync(ProjectDeleteDtoIn item);

        Task<List<ProjectDtoOut>> GetAsync(bool isActivate = true);

        Task Activate(int projectId);
        
        Task ActivateAsync(ProjectDeleteDtoIn item);
    }

    public interface IAgencyTypeBl : IBaseBl<AgencyTypeDtoIn, AgencyTypeDtoOut>
    {        
        Task<List<AgencyTypeDtoOut>> GetAsync();
    }

    public interface IAgencyBl : IBase02Bl<AgencyDtoIn, AgencyDtoOut>
    {
        Task<AgencyListDtoOut> GetAsync(SearchDtoIn searchDtoIn);
        
        Task<List<AgencyDtoOut>> GetByProjectIdAsync(int projectId);
    }

    public interface IPersonBl : IBase02Bl<PersonDtoIn, PersonDtoOut>
    {
        Task<PersonPagerDtoOut> GetAsync(SearchDtoIn personSearch);
        
        Task<List<PersonDtoOut>> GetByAgencyAsync(int agencyId);
    }

    public interface IZipCodeBl
    {
        Task<List<ZipCodeDto>> GetAsync(string zipCode);
    }

    public interface IRoleBl
    {
        Task<List<RoleDto>> GetAsync();
    }

    public interface IDeviceBl:IBaseBl<DeviceDtoIn, DeviceDto>
    {       
        Task<PagerDtoOut> GetAsync(SearchDtoIn deviceSearch);        
    }

     public interface ITicketBl
    {
        Task<List<TicketDto>> GetAsync();

        Task<string> AddAsync(TicketDtoIn item);     

        Task<PagerDtoOut> GetAsync(SearchDtoIn search);   
    }
}