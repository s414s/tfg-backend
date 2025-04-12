using Domain.Entities;
using Infrastructure.Persistence.EntityConfigurators;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Truck> Trucks { get; set; }
    public DbSet<Route> Routes { get; set; }
    public DbSet<Parcel> Pallets { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<MessageThread> MessageThreads { get; set; }
    public DbSet<Freight> Freights { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfigurator());
        modelBuilder.ApplyConfiguration(new TruckEntityConfigurator());
        modelBuilder.ApplyConfiguration(new RouteEntityConfigurator());
        modelBuilder.ApplyConfiguration(new PalletEntityConfigurator());
        modelBuilder.ApplyConfiguration(new CityEntityConfigurator());
        modelBuilder.ApplyConfiguration(new MessageEntityConfiguration());
        modelBuilder.ApplyConfiguration(new MessageThreadEntityConfigurator());
        modelBuilder.ApplyConfiguration(new FreightEntityConfiguration());
    }
}