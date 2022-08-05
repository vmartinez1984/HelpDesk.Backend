namespace Tickets.Core.Entities
{
    public class TicketEntity
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Tags { get; set; }

        public int AgencyId { get; set; }

        public string AgencyName { get; set; }
        
        public int PersonId { get; set; }

        public string PersonName { get; set; }
        
        public string Category { get; set; }

        public string Subcategory { get; set; }

        public string Estado { get; set; }
        
        public int UserId { get; set; }
        
        public string UserName { get; set; }
        
        public string Tipo { get; set; }
        
        public List<LogEntity> ListLog { get; set; }        
        
    }
}