namespace Tickets.Core.Entities
{
    public class SubcategoryEntity
    {
        public string Id { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
        
        public string Name { get; set; }
        
        public string Description { get; set; }
        
        public string Log { get; set; }
        
        public bool IsActive { get; set; }   
    }
}