using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.RepositoryEf
{
    public class RepositoryEf : IRepository
    {
        public RepositoryEf(
            IUserRepository user,
            IProjectRepository projectRepository,
            IAgencyTypeRepository agencyTypeRepository,
            IAgencyRepository agencyRepository,
            IPersonRepository personRepository,
            IRoleRepository roleRepository,
            IDeviceRepository deviceRepository,
            IDeviceStateRepository deviceStateRepository,            
            IResponsiveRepository responsiveRepository
        )
        {
            this.User = user;
            this.Project = projectRepository;
            this.AgencyType = agencyTypeRepository;
            this.Agency = agencyRepository;
            this.Person = personRepository;
            this.Role = roleRepository;
            this.Device = deviceRepository;
            this.DeviceState = deviceStateRepository;
            this.Resposive = responsiveRepository;
        }

        public IUserRepository User { get; }

        public IProjectRepository Project { get; }

        public IAgencyTypeRepository AgencyType { get; }

        public IAgencyRepository Agency { get; }

        public IPersonRepository Person { get; }
        
        public IRoleRepository Role { get; }

        public IDeviceRepository Device { get; }

        public IDeviceStateRepository DeviceState { get; }

        public IResponsiveRepository Resposive { get; }
    }
}