using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk.Core.Entities
{
    public class AgencyEntity: BaseEntity
    {
        [StringLength(255)]
        public string Email;

        [ForeignKey(nameof(ProjectEntity))]
        public int ProjectId { get; set; }

        [ForeignKey(nameof(AgencyTypeEntity))]
        public int AgencyTypeId { get; set; }

        [StringLength(10)]
        public string Code { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(50)]
        public string TownHall { get; set; }

        [StringLength(120)]
        public string Settlement { get; set; }

        [StringLength(5)]
        public string ZipCode { get; set; }
        
        public int UserId { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        public string Log { get; set; }

        [StringLength(255)]
        public string Phone { get; set; }
    }
}