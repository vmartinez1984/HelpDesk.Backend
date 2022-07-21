using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk.Core.Entities
{
    public class UserEntity
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(12)]
        public string Password { get; set; }

        [ForeignKey(nameof(PersonEntity))]
        public int PersonId { get; set; }
        public virtual PersonEntity Person { get; set; }

        [ForeignKey(nameof(RoleEntity))]
        public int RoleId { get; set; }

        public int UserId { get; set; }

        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}