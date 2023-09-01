using Microsoft.EntityFrameworkCore;
using SeatManagementAPI.Models;

namespace SeatManagementAPI
{
    public class SeatManagementDbContext : DbContext
    {
        public SeatManagementDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<City> Cities { get; set; }

        public DbSet<Building> Buildings { get; set; }

        public DbSet<Asset> Assets { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Facility> Facilities { get; set; }

        public DbSet<MeetingRoom> MeetingRooms { get; set; }

        public DbSet<MeetingRoomAssets> MeetingRoomAssets { get; set; }

        public DbSet<Cabin> Cabin { get; set; }

        public DbSet<Seat> Seats { get; set; }

    
    }
}
