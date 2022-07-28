namespace Helpdesk.Core.Interfaces.InterfaceBl
{
    public interface IUnitOfWorkBl
    {
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