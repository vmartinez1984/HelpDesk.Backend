using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class PersonSearchDto : PagerDto
    {
        [Display(Name = "Proyecto")]
        public int ProjectId { get; set; }

        [Display(Name = "Agencia")]
        public int AgencyId { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        [MaxLength(150)]
        public string LastName { get; set; }
    }
}