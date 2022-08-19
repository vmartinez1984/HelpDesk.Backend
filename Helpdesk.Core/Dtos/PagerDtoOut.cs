namespace Helpdesk.Core.Dtos
{
    public class PagerDtoOut
    {
        public int TotalRecordsFiltered { get; set; }

        public int TotalRecords { get; set; }

        public object List { get; set; }

        public int PageCurrent { get; set; }

        public int RecordsPerPage { get; set; }
    }
}