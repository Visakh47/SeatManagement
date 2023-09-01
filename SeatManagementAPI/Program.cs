using Microsoft.EntityFrameworkCore;
using SeatManagementAPI;
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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
