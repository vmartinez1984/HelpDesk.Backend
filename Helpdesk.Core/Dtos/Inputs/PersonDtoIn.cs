using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class PersonDtoIn
    {
        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Los {0} son requeridos")]
        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        public int UserId { get; set; }

        [Required(ErrorMessage = "La {0} es requerida")]
        [Display(Name = "Agencia")]
        public int AgencyId { get; set; }

        [Display(Name = "Notas")]
        [StringLength(1000)]
        public string Notes { get; set; }
    }
}