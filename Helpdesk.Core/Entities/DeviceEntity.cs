using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk.Core.Entities
{
    public class DeviceEntity : BaseEntity
    {
        [StringLength(120)]
        public string SerialNumber { get; set; }

        public DateTime? DateStart { get; set; }

        public DateTime? DateEnd { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        [ForeignKey(nameof(DeviceStateEntity))]
        public int DeviceStateId { get; set; }

        public int UserId { get; set; }

        [ForeignKey(nameof(AgencyEntity))]
        public int? AgencyId { get; set; }
    }

    public class DeviceStateEntity : BaseEntity { }

    public class DeviceSearchEntity : PagerEntity
    {
        public int? ProjectId { get; set; }

        public int? AgencyId { get; set; }

        public string Name { get; set; }

        public string SerialNumber { get; set; }
    }

}