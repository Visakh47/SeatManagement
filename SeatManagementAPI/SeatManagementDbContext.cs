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
        public DbSet<SeatOverview> SeatOverviews { get; set; }
        public DbSet<SeatUnAllocatedView> SeatUnAllocatedViews { get; set; }

        public DbSet<CabinOverview> CabinOverviews { get; set; }
        public DbSet<CabinUnAllocatedView> CabinUnAllocatedViews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SeatOverview>().ToView("Overview").HasNoKey();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<SeatUnAllocatedView>().ToView("UnAllocatedView").HasNoKey();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CabinOverview>().ToView("CabinOverview").HasNoKey();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<CabinUnAllocatedView>().ToView("CabinUnAllocatedView").HasNoKey();
        }
    }
}
