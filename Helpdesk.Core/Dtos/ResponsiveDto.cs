namespace Helpdesk.Core.Dtos
{
    public class ResponsiveDto
    {
        public int Id { get; set; }
        
        public int AgencyId { get; set; }

        public string DocumentId { get; set; }

        public DateTime? DateSend { get; set; }

        public string Email { get; set; }
    }
}