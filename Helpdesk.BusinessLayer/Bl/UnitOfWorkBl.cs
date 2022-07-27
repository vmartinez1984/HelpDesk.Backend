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
            IRoleBl roleBl,
            IDeviceBl deviceBl,
            IFormAgencyBl formAgencyBl,
            IResponsiveBl responsiveBl
        )
        {
            this.User = user;
            this.Project = projectBl;
            this.AgencyType = agencyTypeBl;
            this.Agency = agencyBl;
            this.Person = personBl;
            this.ZipCode = zipCodeBl;
            this.Role = roleBl;
            this.Device = deviceBl;
            this.FormAgency = formAgencyBl;
            this.Responsive = responsiveBl;
        }

        public IUserBl User { get; }
        public IProjectBl Project { get; }
        public IAgencyTypeBl AgencyType { get; }
        public IAgencyBl Agency { get; }
        public IPersonBl Person { get; }
        public IZipCodeBl ZipCode { get; }
        public IRoleBl Role { get; }
        public IDeviceBl Device { get; }
        public IFormAgencyBl FormAgency { get; }
        public IResponsiveBl Responsive { get; }
    }
}