using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk.Core.Entities
{
    public class UserEntity : BaseEntity
    {
        [StringLength(12)]
        public string Password { get; set; }

        [ForeignKey(nameof(PersonEntity))]
        public int PersonId { get; set; }
    }
}