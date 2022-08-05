namespace Tickets.Repository
{
    public class TicketsDbSettings
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }

        public string TicketsCollection { get; set; }
        public string CategoriesCollection { get; set; }
        public string SubcategoriesCollection { get; set; }
    }
}