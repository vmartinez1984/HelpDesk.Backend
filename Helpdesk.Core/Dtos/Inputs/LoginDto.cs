using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class LoginDto
    {
        [Required(ErrorMessage = "El usuario es obligatorio")]
        [Display(Name = "Usuario")]
        [StringLength(20)]
        public string? User { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [Display(Name = "Contraseña")]
        [StringLength(20)]
        public string? Password { get; set; }
    }
}