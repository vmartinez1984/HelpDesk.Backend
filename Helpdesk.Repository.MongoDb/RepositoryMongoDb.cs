using Helpdesk.Core.Interfaces.IRepositories;

namespace Helpdesk.Repository.MongoDb
{
    public class RepositoryMongoDb : IRepositoryMongoDb
    {
        public RepositoryMongoDb(
            IFormAgencyRepository formAgencyRepository
        )
        {
            this.FormAgency = formAgencyRepository;
        }
        public IFormAgencyRepository FormAgency { get; }
    }
}