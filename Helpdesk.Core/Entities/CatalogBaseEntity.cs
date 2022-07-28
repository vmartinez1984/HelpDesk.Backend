using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Entities
{
    public class CatalogBaseEntity : BaseAEntity
    {

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }

    public class BaseEntity : CatalogBaseEntity { }

    public class BaseAEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}