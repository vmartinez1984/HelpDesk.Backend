using System.ComponentModel.DataAnnotations;

namespace Helpdesk.Core.Entities
{
    public class CatalogBaseEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }

    public class BaseEntity : CatalogBaseEntity
    {
        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }
}