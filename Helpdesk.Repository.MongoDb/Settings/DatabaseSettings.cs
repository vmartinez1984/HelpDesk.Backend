namespace Helpdesk.Repository.MongoDb.Settings
{
    public class DatabaseSettings
    {
          public string ConnectionString { get; set; } = null!;

        public string DatabaseName { get; set; } = null!;

        public string FormAgencyCollectionName { get; set; } = null!;
    }
}