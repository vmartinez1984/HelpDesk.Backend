namespace Helpdesk.Core.Entities
{
    public class AgencySearchEntity: PagerEntity
    {
        public int? ProjectId { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }
    }

    public class AgencySearchEntityOut: AgencySearchEntity
    {
        public List<AgencyEntity>? ListAgencies { get; set; }        
    }
}