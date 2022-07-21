using System.ComponentModel.DataAnnotations;
using Helpdesk.Core.Dtos.Outputs;
using Helpdesk.Core.Validators;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class UserDtoIn : PersonDtoIn
    {
        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Rol")]
        public int RoleId { get; set; }

        [Required(ErrorMessage = "El {0} es requerido")]
        [Display(Name = "Proyecto")]
        public int ProjectId { get; set; }

        [Required(ErrorMessage = ("El correo es requerido"))]
        [StringLength(255)]
        [DataType(DataType.EmailAddress)]
        [EmailExists]
        public string Email { get; set; }

        [Required(ErrorMessage = ("La contraseña requerida"))]
        [StringLength(12)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }

    public class UserSearchDtoIn : PagerDto
    {
        [Display(Name = "Proyecto")]
        public int? ProjectId { get; set; }
        
        [Display(Name = "Agencia")]
        public int? AgencyId { get; set; }

        [Display(Name = "Correo")]
        public string UserEmail { get; set; }
    }
}
