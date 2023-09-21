using AssetManagementAPI.ControllerServices;
using Microsoft.EntityFrameworkCore;
using SeatManagementAPI;
using SeatManagementAPI.Controllers;
using SeatManagementAPI.Interfaces;
using SeatManagementAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<SeatManagementDbContext>(options =>
    options.UseSqlServer("name=ConnectionStrings:DefaultConnection"),ServiceLifetime.Singleton);

//Look Up 
builder.Services.AddSingleton<IRepository<City>,Repository<City>>();
builder.Services.AddSingleton<IRepository<Building>, Repository<Building>>();
builder.Services.AddSingleton<IRepository<Asset>, Repository<Asset>>();
builder.Services.AddSingleton<IRepository<Cabin>, Repository<Cabin>>();

//Tables
builder.Services.AddSingleton<IRepository<Department>, Repository<Department>>();
builder.Services.AddSingleton<IRepository<Employee>, Repository<Employee>>();
builder.Services.AddSingleton<IRepository<Facility>, Repository<Facility>>();
builder.Services.AddSingleton<IRepository<MeetingRoom>, Repository<MeetingRoom>>();
builder.Services.AddSingleton<IRepository<MeetingRoomAssets>, Repository<MeetingRoomAssets>>();
builder.Services.AddSingleton<IRepository<Seat>, Repository<Seat>>();
builder.Services.AddSingleton<IRepository<SeatOverview>, Repository<SeatOverview>>();
builder.Services.AddSingleton<IRepository<SeatUnAllocatedView>, Repository<SeatUnAllocatedView>>();
builder.Services.AddSingleton<IRepository<CabinOverview>, Repository<CabinOverview>>();
builder.Services.AddSingleton<IRepository<CabinUnAllocatedView>, Repository<CabinUnAllocatedView>>();

builder.Services.AddSingleton<IAssetService, AssetService>();
builder.Services.AddSingleton<IBuildingService, BuildingService>();
builder.Services.AddSingleton<ICabinService, CabinService>();
builder.Services.AddSingleton<ICityService, CityService>();

builder.Services.AddSingleton<IDepartmentService, DepartmentService>();
builder.Services.AddSingleton<IEmployeeService, EmployeeService>();
builder.Services.AddSingleton<IFacilityService, FacilityService>();
builder.Services.AddSingleton<IMeetingRoomService, MeetingRoomService>();
builder.Services.AddSingleton<IMeetingRoomAssetsService, MeetingRoomAssetsService>();
builder.Services.AddSingleton<ISeatService, SeatService>();
builder.Services.AddSingleton<IReportService, ReportService>();

builder.Services.AddAuthentication("MyCookieAuth").AddCookie("MyCookieAuth", options =>
{
    options.Cookie.Name = "MyCookieAuth";
    //options.LoginPath = "/Auth/LoginASync";
    //options.AccessDeniedPath = "/unauthorized";
    options.ExpireTimeSpan = TimeSpan.FromSeconds(300);
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = 401;
        return Task.CompletedTask;
    };
});


builder.Services.AddAuthorization(options =>
    {
        options.AddPolicy("User",
            policy => policy.RequireRole("User"));
    }
);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
