namespace Helpdesk.Core.Dtos.Inputs
{
    public class PersonSearchDtonIn : PagerDtoIn
    {
        public int? ProjectId { get; set; }

        public int? AgencyId { get; set; }

        public string PersonName { get; set; }

        public string PersonLastName { get; set; }
    }

    public class PagerDtoIn
    {
        public int PageCurrent { get; set; }

        public int RecordsPerPage { get; set; }

        public int TotalRecords { get; set; }
    }
}