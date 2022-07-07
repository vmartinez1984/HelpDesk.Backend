using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class PersonDtoOut
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellidos")]
        public string LastName { get; set; }

        [StringLength(1000)]
        [Display(Name = "Notas")]
        public string Notes { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Agencia")]
        public int AgencyId { get; set; }

        [Display(Name = "Agencia")]
        public string AgencyName { get; set; }

        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; }
    }
}