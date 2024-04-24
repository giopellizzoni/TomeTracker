using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TomeTracker.Domain.Repositories;
using TomeTracker.Infra.Persistence.Context;
using TomeTracker.Infra.Persistence.Repositories;

namespace TomeTracker.Infra.Persistence;

public static class PersistenceModule
{

    public static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
            .AddDatabaseContext(configuration)
            .AddRepositories()
            .AddUnityOfWork();

        return services;
    }

    private static IServiceCollection AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("TomeTrackerDB");
        services.AddDbContext<TomeTrackerDbContext>(opt => opt.UseSqlServer(connectionString));
        // services.AddDbContext<TomeTrackerDbContext>(opt => opt.UseInMemoryDatabase("TomeTrackerDB"));

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }

    private static IServiceCollection AddUnityOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

}
