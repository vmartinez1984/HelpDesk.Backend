using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk.Core.Entities
{
    public class PersonEntity : BaseEntity
    {

        [StringLength(255)]
        public string? LastName { get; set; }

        [ForeignKey(nameof(UserEntity))]
        public int UserId { get; set; }

        [ForeignKey(nameof(AgencyEntity))]
        public int AgencyId { get; set; }

        [StringLength(1000)]
        public string? Notes { get; set; }
    }
}