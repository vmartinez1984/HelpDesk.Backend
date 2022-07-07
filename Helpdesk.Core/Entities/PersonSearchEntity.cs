namespace Helpdesk.Core.Entities
{
    public class PersonSearchEntity :PagerEntity
    {
        public int? ProjectId { get; set; }

        public int? AgencyId { get; set; }

        public string PersonName { get; set; }

        public string PersonLastName { get; set; }
    }
}