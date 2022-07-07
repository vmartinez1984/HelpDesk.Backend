using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class AgencySearchDtoOut: PagerDto
    {
        [Display(Name = "Proyecto")]
        public int? ProjectId { get; set; }

        [Display(Name = "Agencia")]
        public string? Name { get; set; }

        [Display(Name = "Clave")]
        public string? Code { get; set; }
    }
}