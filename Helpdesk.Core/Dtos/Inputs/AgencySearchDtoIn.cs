using System.ComponentModel.DataAnnotations;
using Helpdesk.Core.Dtos.Outputs;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class AgencySearchDtoIn : SearchDto
    {
        [Display(Name = "Proyecto")]
        public int? ProjectId { get; set; }

        [Display(Name = "Agencia")]
        public string Name { get; set; }

        [Display(Name = "Clave")]
        public string Code { get; set; }
    }
}