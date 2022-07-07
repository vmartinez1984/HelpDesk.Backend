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

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
//Autenticacion
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
    options =>
    {
        options.LoginPath = "/Login/Index";
        options.LogoutPath = "/Account/Logout";
    });
//builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<AppDbContext>();
//Repositories
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IAgencyTypeRepository, AgencyTypeRepository>();
builder.Services.AddScoped<IAgencyRepository, AgencyRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRepository, RepositoryEf>();
//Services
builder.Services.AddScoped<IZipCodeService, ZipCodeService>();
//Business layer
builder.Services.AddScoped<IPersonBl, PersonBl>();
builder.Services.AddScoped<IAgencyBl, AgencyBl>();
builder.Services.AddScoped<IAgencyTypeBl, AgencyTypeBl>();
builder.Services.AddScoped<IProjectBl, ProjectBl>();
builder.Services.AddScoped<IUserBl, UserBl>();
builder.Services.AddScoped<IZipCodeBl, ZipCodeBl>();
builder.Services.AddScoped<IUnitOfWorkBl, UnitOfWorkBl>();
//Mappers
var mapperConfig = new MapperConfiguration(mapperConfig =>
{
    mapperConfig.AddProfile<AgencyTypeMapper>();
    mapperConfig.AddProfile<AgencySearchInMapper>();
    mapperConfig.AddProfile<AgencySearchOutMapper>();
    mapperConfig.AddProfile<AgencyMapper>();
    mapperConfig.AddProfile<AgencySearchResultOutMapper>();
    mapperConfig.AddProfile<PersonMapper>();
    mapperConfig.AddProfile<PersonSearchMapper>();
    mapperConfig.AddProfile<ProjectMapper>();
    mapperConfig.AddProfile<PagerMapper>();
    mapperConfig.AddProfile<UserMapper>();
    mapperConfig.AddProfile<ZipCodeMapper>();
    mapperConfig.AddProfile<ImplementsMapper>();
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
//Autenticacion en el middleware
app.UseAuthentication();
app.UseAuthorization();

//app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
