namespace API;

public static class DependencyInjection
{
    public static IServiceCollection AddApi(this IServiceCollection services)
    {
        services.AddMediatR(configuration: cfg =>
            cfg.RegisterServicesFromAssembly(assembly: typeof(DependencyInjection).Assembly));

        return services;
    }
}