using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class ProjectDtoIn
    {
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        [StringLength(255)]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        
        [StringLength(1000)]        
        [Display(Name = "Notas")]
        public string Notes { get; set; }

        public int UserId { get; set; }
    }

    public class ProjectDeleteDtoIn: ProjectDtoIn {
        public int Id { get; set; }

        public int DeleteUserId { get; set; }

        public DateTime DateRegistration { get; set; }

        [Required(ErrorMessage = "Anote el motivo")]
        [StringLength(255)]        
        [Display(Name = "Anote motivo")]
        public string Reason { get; set; }
    }
}