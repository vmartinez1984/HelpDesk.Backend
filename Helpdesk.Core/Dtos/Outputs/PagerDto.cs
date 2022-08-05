namespace Helpdesk.Core.Dtos.Outputs
{
    public class PagerDto
    {
        public int PageCurrent { get; set; } = 1;
		public int RecordsPerPage { get; set; } = 10;
		public int TotalRecords { get; set; }
		public int CountPage
		{
			get
			{
				return (int)Math.Ceiling((double)TotalRecords / RecordsPerPage);
			}
		}

		public int TotalRecordsFiltered { get; set; }
    }
}