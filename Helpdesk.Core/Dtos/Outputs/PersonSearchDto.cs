using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class PersonSearchDto : PagerDto
    {
        public int TotalRecordsFiltered { get; set; }
    }
}