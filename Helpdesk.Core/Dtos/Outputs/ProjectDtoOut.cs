using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Outputs
{
    public class ProjectDtoOut
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [StringLength(1000)]
        [Display(Name = "Notas")]
        public string Notes { get; set; }

        [Display(Name = "Fecha de registro")]
        [DataType(DataType.Date)]
        public DateTime DateRegistration { get; set; }

        public int UserId { get; set; }

        [Display(Name = "Usuario que registro")]
        public string UserName { get; set; }

        [Display(Name = "Total de agencias")]
        public int TotalAgencies { get; set; }
    }
}
