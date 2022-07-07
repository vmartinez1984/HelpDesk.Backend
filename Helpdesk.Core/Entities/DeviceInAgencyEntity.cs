using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk.Core.Entities
{
    public class DeviceInAgencyEntity : BaseEntity
    {
        [ForeignKey(nameof(AgencyEntity))]
        public int AgencyId { get; set; }


        [ForeignKey(nameof(DeviceEntity))]
        public int DeviceId { get; set; }
        
        [ForeignKey(nameof(UserEntity))]
        public int UserId { get; set; }
        
    }
}