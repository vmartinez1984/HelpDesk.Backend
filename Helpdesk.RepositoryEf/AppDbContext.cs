using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace helpdesk.RepositoryEf
{
    public class AppDbContext : DbContext
    {
        private IConfiguration _configuration;

        public AppDbContext()
        {

        }

        public AppDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        public DbSet<UserEntity> User { get; set; }
    }
}