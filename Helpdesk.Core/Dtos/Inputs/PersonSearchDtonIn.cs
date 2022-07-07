using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class PersonSearchDtonIn : PagerDtoIn
    {
        [Display(Name = "Proyecto")]
        public int? ProjectId { get; set; }

        [Display(Name = "Agencia")]
        public int? AgencyId { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        public string LastName { get; set; }
    }

    public class PagerDtoIn
    {
        public int PageCurrent { get; set; } = 1;

        public int RecordsPerPage { get; set; } = 10;

        public int TotalRecords { get; set; }
    }
}