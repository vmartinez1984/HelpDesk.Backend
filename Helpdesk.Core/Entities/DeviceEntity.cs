using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk.Core.Entities
{
    public class DeviceEntity : BaseEntity
    {
        [StringLength(120)]
        public string SerialNumber { get; set; }

        public DateTime LicenseDateStart { get; set; }

        public DateTime LicenseDateEnd { get; set; }

        [StringLength(1000)]
        public string Notes { get; set; }

        [Required]
        [ForeignKey(nameof(DeviceStateEntity))]
        public int DeviceStateId { get; set; }
    }

    public class DeviceStateEntity : BaseEntity { }
}