using Core.Abstractions;
using Core.Options;
using Core.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CaOptions>(configuration.GetSection("CA"));
        services.AddScoped<ICaRepository, CaRepository>();
        services.AddScoped<IIndexParser, IndexParser>();
        return services;
    }
}