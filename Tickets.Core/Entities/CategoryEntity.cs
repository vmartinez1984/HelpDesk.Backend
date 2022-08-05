namespace Tickets.Core.Entities
{
    public class CategoryEntity
    {
        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }

        public string Log { get; set; }
        
        public bool IsActive { get; set; }        
    }
}