namespace Helpdesk.Core.Dtos.Inputs
{
    public class SearchDto
    {
        public int PageCurrent { get; set; } = 1;

        public int RecordsPerPage { get; set; } = 10;

        public int TotalRecords { get; set; }
    }
}