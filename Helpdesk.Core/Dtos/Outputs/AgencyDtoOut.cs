namespace Helpdesk.Core.Dtos.Outputs
{
    public class AgencyDtoOut
    {
        public int AgencyTypeId { get; set; }

        public string AgencyTypeName { get; set; }

        public string Code { get; set; }

        public string Address { get; set; }

        public string State { get; set; }

        public string TownHall { get; set; }

        public string Settlement { get; set; }

        public string ZipCode { get; set; }

        public int UserId { get; set; }

        public string Notes { get; set; }

        public string Log { get; set; }

        public string Phone { get; set; }

        public string email;
    }
}