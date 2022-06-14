namespace Helpdesk.Core.Interfaces.InterfaceBl
{
    public interface IUnitOfWorkBl
    {
        public IUserBl User { get; }
        public IProjectBl Project { get; }

        public IAgencyTypeBl AgencyType { get; }
        public IAgencyBl Agency { get; }
        public IPersonBl Person { get; }
    }
}