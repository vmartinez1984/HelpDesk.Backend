namespace Helpdesk.Core.Entities
{
    public class AgencySearchEntity : SearchEntity
    {
        public int? ProjectId { get; set; }

        public string? Name { get; set; }

        public string? Code { get; set; }
    }

    public class SearchEntity
    {
        public int PageCurrent { get; set; }

        public int RecordsPerPage { get; set; }

        public int TotalRecords { get; set; }
    }
}