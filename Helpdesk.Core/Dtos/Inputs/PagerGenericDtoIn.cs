namespace Helpdesk.Core.Dtos.Inputs
{
    public class PagerGenericDtoIn<T> where T :class
    {
        public int PageCurrent { get; set; }

        public int RecordsPerPage { get; set; }

        public int TotalRecords { get; set; }

        public int TotalPages { get; set; }

        public string SearchCurrent { get; set; }

        public string OrderCurrent { get; set; }

        public string TypeOrderCurrent { get; set; }

        public IEnumerable<T> Result { get; set; }
    }
}