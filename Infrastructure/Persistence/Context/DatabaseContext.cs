using Domain.Entities;
using Infrastructure.Persistence.EntityConfigurators;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Infrastructure.Persistence.Context;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    //    se inyecta la configuración para poder leer el connection string desde ella
    //    protected readonly IConfiguration Configuration;
    //    public DatabaseContext(IConfiguration configuration)
    //    {
    //        Configuration = configuration;
    //    }

    //    protected override void OnConfiguring(DbContextOptionsBuilder options)
    //    {
    //        // connect to postgres with connection string from app settings
    //        options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));

    //        //base.OnConfiguring(options);
    //    }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserEntityConfigurator());

        // TODO hashear contraseñas
        modelBuilder.Entity<User>().HasData([
            new User{ Id = 1, Name = "alberto", Password = "root", Email = "alberto@gmail.com" },
            new User{ Id = 2, Name = "ana", Password = "root", Email = "ana@gmail.com" },
            ]);

        //base.OnModelCreating(modelBuilder);
    }
}