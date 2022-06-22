using AutoMapper;
using Helpdesk.RepositoryEf.Contexts;
using Helpdesk.BusinessLayer.Bl;
using Helpdesk.Core.Interfaces.InterfaceBl;
using Helpdesk.Core.Interfaces.IRepositories;
using Helpdesk.Core.Mappers;
using Helpdesk.RepositoryEf;
using Helpdesk.RepositoryEf.Repositories;
using Heldesk.Api.Middlewares;

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
//Repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAgencyTypeRepository, AgencyTypeRepository>();
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRepository, RepositoryEf>();
//Business layer
builder.Services.AddScoped<IPersonBl, PersonBl>();
builder.Services.AddScoped<IAgencyBl, AgencyBl>();
builder.Services.AddScoped<IAgencyTypeBl, AgencyTypeBl>();
builder.Services.AddScoped<IProjectBl, ProjectBl>();
builder.Services.AddScoped<IUserBl, UserBl>();
builder.Services.AddScoped<IUnitOfWorkBl, UnitOfWorkBl>();
//Mappers
var mapperConfig = new MapperConfiguration(mapperConfig =>
{
    mapperConfig.AddProfile<UserMapper>();
    mapperConfig.AddProfile<ProjectMapper>();
    mapperConfig.AddProfile<AgencyTypeMapper>();
    mapperConfig.AddProfile<AgencyMapper>();
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
