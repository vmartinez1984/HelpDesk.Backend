namespace Helpdesk.Core.Dtos.Inputs
{
    public class SearchDto
    {
        public int PageCurrent { get; set; } = 1;

        public int RecordsPerPage { get; set; } = 10;
        // {
        //     get
        //     {
        //         if (RecordsPerPage > 100)
        //             return 100;
        //         else
        //             return RecordsPerPage;
        //     }

        //     set
        //     {
        //         if (value <= 0)
        //             RecordsPerPage = 10;
        //         else
        //             RecordsPerPage = value;
        //     }
        // }

        public int TotalRecords { get; set; }
    }
}