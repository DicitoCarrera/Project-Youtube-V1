using Domain.Interfaces.Auth;
using Domain.Interfaces.Persistance;
using Infrastructure.Auth;
using Infrastructure.Persistance;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<ITokenProvider, JwtTokenProvider>();
        services.AddSingleton<IUserRepository, MongoUserRepository>();

        return services;
    }
}