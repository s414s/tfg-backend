using Domain.Entities;
using Infrastructure.Persistence.EntityConfigurators;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Trailer> Trailers { get; set; }
    public DbSet<Truck> Trucks { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Pallet> Pallets { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Shift> Shifts { get; set; }
    public DbSet<RouteShift> RouteShifts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfigurator());
        modelBuilder.ApplyConfiguration(new TrailerEntityConfigurator());
        modelBuilder.ApplyConfiguration(new TruckEntityConfigurator());
        modelBuilder.ApplyConfiguration(new RouteEntityConfigurator());
        modelBuilder.ApplyConfiguration(new PalletEntityConfigurator());
        modelBuilder.ApplyConfiguration(new CityEntityConfigurator());
        modelBuilder.ApplyConfiguration(new ShiftEntityConfigurator());
        modelBuilder.ApplyConfiguration(new RouteShiftConfigurator());
    }
}