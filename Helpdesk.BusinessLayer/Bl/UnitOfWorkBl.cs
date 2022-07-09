using Helpdesk.Core.Interfaces.InterfaceBl;

namespace Helpdesk.BusinessLayer.Bl
{
    public class UnitOfWorkBl : IUnitOfWorkBl
    {
        public UnitOfWorkBl(
            IUserBl user,
            IProjectBl projectBl,
            IAgencyTypeBl agencyTypeBl,
            IAgencyBl agencyBl,
            IPersonBl personBl,
            IZipCodeBl zipCodeBl,
            IRoleBl roleBl
        )
        {
            this.User = user;
            this.Project = projectBl;
            this.AgencyType = agencyTypeBl;
            this.Agency = agencyBl;
            this.Person = personBl;
            this.ZipCode = zipCodeBl;
            this.Role = roleBl;
        }

        public IUserBl User { get; }
        public IProjectBl Project { get; }
        public IAgencyTypeBl AgencyType { get; }
        public IAgencyBl Agency { get; }
        public IPersonBl Person { get; }
        public IZipCodeBl ZipCode { get; }
        public IRoleBl Role { get; }
    }
}