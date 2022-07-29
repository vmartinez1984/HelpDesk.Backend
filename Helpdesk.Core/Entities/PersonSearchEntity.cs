namespace Helpdesk.Core.Entities
{
    public class PersonSearchEntity : PagerEntity
    {
        public string Search { get; set; }

        public string SortColumn { get; set; }
        
        public string SortColumnDir { get; set; }

        public int TotalRecordsFiltered { get; set; }
    }
}