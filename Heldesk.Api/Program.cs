using AutoMapper;
using Helpdesk.RepositoryEf.Contexts;
using Helpdesk.BusinessLayer.Bl;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.Core.Mappers;
using Helpdesk.RepositoryEf;
using Helpdesk.RepositoryEf.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Helpdesk.Services.ZipCodes;
using Helpdesk.Core.Interfaces.IServices;
using Helpdesk.Repository.MongoDb;
using Helpdesk.Repository.MongoDb.Settings;
using Helpdesk.Notifications;
using Rotativa.AspNetCore;
using Helpdesk.WorkerServices;
using Tickets.Core.Interfaces.IRepositories;
using Tickets.Repository;
using Tickets.Core.Interfaces.IBusinessLayer;
using Tickets.Core.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("*")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<AppDbContext>();
//Configuration mongoDb
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("HelpdeskDatabaseMongoDb"));
builder.Services.Configure<TicketsDbSettings>(builder.Configuration.GetSection("TicketsDbSettings"));
builder.Services.AddScoped<AppDbContext>();
//Repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAgencyTypeRepository, AgencyTypeRepository>();
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();
builder.Services.AddScoped<IDeviceStateRepository, DeviceStateRepository>();
builder.Services.AddScoped<IResponsiveRepository, ResposiveRepository>();
builder.Services.AddScoped<IRepository, RepositoryEf>();
//Mongo Db
builder.Services.AddScoped<IFormAgencyRepository, FormAgencyRepository>();
builder.Services.AddScoped<IRepositoryMongoDb, RepositoryMongoDb>();
//Tickets Repository MongoDB
builder.Services.AddScoped<ITicketRepository, TicketRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ISubcategoryRepository, SubcategoryRepository>();
builder.Services.AddScoped<IStateRepository, StateRepository>();
builder.Services.AddScoped<IRepositoryTickets, RepositoryTickets>();
//Services
builder.Services.AddScoped<IZipCodeService, ZipCodeService>();
//Business layer
builder.Services.AddScoped<IPersonBl, PersonBl>();
builder.Services.AddScoped<IAgencyBl, AgencyBl>();
builder.Services.AddScoped<IFormAgencyBl, FormAgencyBl>();
builder.Services.AddScoped<IAgencyTypeBl, AgencyTypeBl>();
builder.Services.AddScoped<IProjectBl, ProjectBl>();
builder.Services.AddScoped<IUserBl, UserBl>();
builder.Services.AddScoped<IZipCodeBl, ZipCodeBl>();
builder.Services.AddScoped<IRoleBl, RoleBl>();
builder.Services.AddScoped<IDeviceBl, DeviceBl>();
builder.Services.AddScoped<IResponsiveBl, ResponsiveBl>();
builder.Services.AddScoped<ITicketBl, TicketBl>();
builder.Services.AddScoped<ICategoryBl, CategoryBl>();
builder.Services.AddScoped<ISubcategoryBl, SubcategoryBl>();
builder.Services.AddScoped<IUnitOfWorkBl, UnitOfWorkBl>();
//Services
builder.Services.AddSingleton<EmailNotification>();
builder.Services.AddHostedService<TimedHostedService>();

//Mappers
var mapperConfig = new MapperConfiguration(mapperConfig =>
{
    mapperConfig.AddProfile<ImplementsMapper>();
    mapperConfig.AddProfile<TicketsMapper>();
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<ExampleMiddleware>();

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
