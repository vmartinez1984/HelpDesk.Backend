namespace Helpdesk.Core.Entities
{
    public class UserSearchEntity: PagerEntity
    {
        public int? ProjectId { get; set; }

        public int? AgencyId { get; set; }

        public string UserEmail { get; set; }
    }
}