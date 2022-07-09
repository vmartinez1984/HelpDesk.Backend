using Helpdesk.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Helpdesk.RepositoryEf.Contexts
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
                string connectionString;

                //connectionString = _configuration.GetConnectionString("DefaultConnection");
                connectionString = "Server=localhost; Port=13306; Database=HelpDesk; Uid=root; Pwd=;";
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
            }
        }

        public DbSet<AgencyEntity> Agency { get; set; }
        public DbSet<AgencyTypeEntity> AgencyType { get; set; }
        public DbSet<DeviceEntity> Device { get; set; }
        public DbSet<DeviceStateEntity> DeviceState { get; set; }
        public DbSet<PersonEntity> Person { get; set; }
        public DbSet<ProjectEntity> Project { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<RoleEntity> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>().HasData(
                new ProjectEntity
                {
                    Id = 1,
                    Name = "Proyecto inicial",
                    DateRegistration = DateTime.Now,
                    IsActive = true,
                    UserId = 1,
                    Notes = "Proyecto inicial"
                }
            );

            modelBuilder.Entity<AgencyTypeEntity>().HasData(
                new AgencyTypeEntity { Id = 1, Name = "Corporativo", DateRegistration = DateTime.Now, IsActive = true },
                new AgencyTypeEntity { Id = 2, Name = "Matriz", DateRegistration = DateTime.Now, IsActive = true },
                new AgencyTypeEntity { Id = 3, Name = "Sucursal", DateRegistration = DateTime.Now, IsActive = true },
                new AgencyTypeEntity { Id = 4, Name = "Punto de venta", DateRegistration = DateTime.Now, IsActive = true }
            );

            modelBuilder.Entity<AgencyEntity>().HasData(
                new AgencyEntity
                {
                    Id = 1,
                    Address = "Domicilio conocido",
                    AgencyTypeId = 1,
                    Code = "01",
                    DateRegistration = DateTime.Now,
                    IsActive = true,
                    Name = "Principal",
                    ProjectId = 1,
                    Settlement = string.Empty,
                    State = string.Empty,
                    TownHall = string.Empty,
                    UserId = 1,
                    Notes = string.Empty,
                    Log = string.Empty,
                    Phone = string.Empty,
                    email = string.Empty,
                    ZipCode = string.Empty
                }
            );

            modelBuilder.Entity<PersonEntity>().HasData(
                new PersonEntity
                {
                    Id = 1,
                    AgencyId = 1,
                    Name = "Admin",
                    LastName = "Admin",
                    UserId = 1,
                    DateRegistration = DateTime.Now,
                    IsActive = true
                }
            );

            modelBuilder.Entity<RoleEntity>().HasData(
                new RoleEntity {Id = 1, Name = "Nivel 1", DateRegistration= DateTime.Now, IsActive = true},
                new RoleEntity {Id = 2, Name = "Nivel 2", DateRegistration= DateTime.Now, IsActive = true},
                new RoleEntity {Id = 3, Name = "Nivel 3", DateRegistration= DateTime.Now, IsActive = true},
                new RoleEntity {Id = 4, Name = "Nivel 4", DateRegistration= DateTime.Now, IsActive = true}
            );

            modelBuilder.Entity<UserEntity>().HasData(
                new UserEntity
                {
                    Id = 1,
                    DateRegistration = DateTime.Now,
                    IsActive = true,
                    Email = "administrador",
                    Password = "123456",
                    PersonId = 1,
                    RoleId = 1
                }
            );

            modelBuilder.Entity<DeviceStateEntity>().HasData(
                new DeviceStateEntity { Id = 1, Name = "En almacen", IsActive = true, DateRegistration = DateTime.Now },
                new DeviceStateEntity { Id = 2, Name = "Asignado", IsActive = true, DateRegistration = DateTime.Now },
                new DeviceStateEntity { Id = 3, Name = "Merma", IsActive = true, DateRegistration = DateTime.Now }
            );
        }
    }//end class
}