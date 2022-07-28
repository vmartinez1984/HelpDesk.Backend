using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Helpdesk.Core.Entities
{
    public class FormAgencyEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        //[Required]
        //[ForeignKey(nameof(ProjectEntity))]
        public int ProjectId { get; set; }

        //[Required]
        //[ForeignKey(nameof(AgencyEntity))]
        public int AgencyId { get; set; }

        //public virtual AgencyEntity Agency { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        public string TextResponsive { get; set; }

        public string Notes { get; set; }

        public virtual List<DeviceEntity> ListDevices { get; set; }

        [Required]
        public DateTime DateRegistration { get; set; } = DateTime.Now;

        [Required]
        public bool IsActive { get; set; } = true;
    }

    public class FormAgencyDevicesEntity : BaseEntity
    {
        [Required]
        [ForeignKey(nameof(FormAgencyEntity))]
        public int FormAgencyId { get; set; }
        public virtual FormAgencyEntity FormAgency { get; set; }

        [Required]
        [ForeignKey(nameof(DeviceEntity))]
        public int DeviceId { get; set; }
        public virtual DeviceEntity Device { get; set; }
    }
}