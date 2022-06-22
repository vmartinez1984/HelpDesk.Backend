using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Dtos.Inputs
{
    public class UserDtoIn
    {
        [Required]
        [StringLength(255)]
        public string? Name { get; set; }

        [Required]
        [StringLength(12)]
        public string? Password { get; set; }

        [Required]
        public int PersonId { get; set; }
    }
}
