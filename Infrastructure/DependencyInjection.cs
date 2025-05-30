using Domain.Contracts;
using Infrastructure.Interceptors;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Implementations;
using Infrastructure.Persistence.Implementations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        services.AddDbContext<DatabaseContext>((sp, options) =>
        {
            options.UseNpgsql(connectionString);
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            //.AddInterceptors(myProvider.GetRequiredService<AuditableEntityInterceptor>());
        });

        services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        return services;
    }
}

public class JwtSettings
{
    public string Key { get; set; } = string.Empty;
    public string Issuer { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
}
