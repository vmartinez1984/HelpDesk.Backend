namespace Helpdesk.Core.Entities
{
    public class PersonSearchEntity : PagerEntity
    {
        public int? ProjectId { get; set; }

        public int? AgencyId { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }
    }
}