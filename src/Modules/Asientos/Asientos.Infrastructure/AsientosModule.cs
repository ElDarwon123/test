using Asientos.Application.Commands.CreateAsiento;
using Asientos.Application.Contracts;
using Asientos.Application.Queries.GetAllAsientos;
using Asientos.Infrastructure.Persistence.Repositories;
using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Asientos.Infrastructure;

public static class AsientosModule
{
    public static IServiceCollection AddAsientosModule(this IServiceCollection services)
    {
        services.AddScoped<IAsientoRepository, AsientoRepository>();

        services.AddLiteBus(liteBus =>
        {
            liteBus.AddCommandModule(module => module.RegisterFromAssembly(typeof(CreateAsientoCommandHandler).Assembly));
            liteBus.AddQueryModule(module => module.RegisterFromAssembly(typeof(GetAllAsientosQueryHandler).Assembly));
        });

        return services;
    }
}
