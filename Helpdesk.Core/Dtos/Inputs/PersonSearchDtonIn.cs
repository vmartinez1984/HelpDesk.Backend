using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class PersonSearchDtonIn : PagerDtoIn
    {
        public string Search { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
    }

    public class PagerDtoIn
    {
        public int PageCurrent { get; set; } = 1;

        public int RecordsPerPage { get; set; } = 10;

        public int TotalRecords { get; set; }
    }
}