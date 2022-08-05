namespace Tickets.Core.Entities
{
    public class LogEntity
    {
        public string Id { get; set; }

        public string Content { get; set; }       
        
        public string UserName { get; set; }
        
        public DateTime DateRegistration { get; set; }
        
        public string State { get; set; }
    }
}