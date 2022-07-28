using System.ComponentModel.DataAnnotations.Schema;

namespace Helpdesk.Core.Entities
{
    public class ResponsiveEntity : BaseAEntity
    {
        [ForeignKey(nameof(AgencyEntity))]
        public int AgencyId { get; set; }

        public string DocumentId { get; set; }

        public DateTime? DateSend { get; set; }

        public string Email { get; set; }       
        
    }
}