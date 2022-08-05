namespace Helpdesk.Core.Dtos
{
    public class SearchDtoIn
    {
        public int PageCurrent { get; set; }
        public int RecordsPerPage { get; set; }
        public string Search { get; set; }
        public string SortColumn { get; set; }
        public string SortColumnDir { get; set; }
    }
}