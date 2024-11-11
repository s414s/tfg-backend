using Domain.Contracts;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.Implementations;
using Infrastructure.Persistence.Implementations.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
        services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        services.AddScoped<IUsersRepository, UsersRepository>();
        //services.AddScoped(typeof(IReviewsRepository), typeof(ReviewsRepository));
        return services;
    }
}
