using Helpdesk.Core.Interfaces.InterfaceBl;
using Tickets.Core.Interfaces.IBusinessLayer;

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
            IResponsiveBl responsiveBl,
            ITicketBl ticketBl,
            ICategoryBl categoryBl,
            ISubcategoryBl subcategoryBl
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
            this.Ticket = ticketBl;
            this.Category = categoryBl;
            this.Subcategory = subcategoryBl;
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

        public ICategoryBl Category { get; }

        public ITicketBl Ticket { get; }

        public ISubcategoryBl Subcategory { get; }
    }
}