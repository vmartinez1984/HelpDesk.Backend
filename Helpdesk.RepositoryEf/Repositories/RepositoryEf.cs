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
            IPersonRepository personRepository
        )
        {
            this.User = user;
            this.Project = projectRepository;
            this.AgencyType = agencyTypeRepository;
            this.Agency = agencyRepository;
            this.Person = personRepository;
        }

        public IUserRepository User { get;}
        public IProjectRepository Project { get; }
        public IAgencyTypeRepository AgencyType { get; }
        public IAgencyRepository Agency { get; }
        public IPersonRepository Person { get; }
    }
}