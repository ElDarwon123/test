using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;
using Salas.Application.Commands.CreateSala;
using Salas.Application.Contracts;
using Salas.Application.Queries.GetAllSalas;
using Salas.Infrastructure.Persistence.Repositories;

namespace Salas.Infrastructure;

public static class SalasModule
{
    public static IServiceCollection AddSalasModule(this IServiceCollection services)
    {
        services.AddScoped<ISalaRepository, SalaRepository>();

        services.AddLiteBus(liteBus =>
        {
            liteBus.AddCommandModule(module => module.RegisterFromAssembly(typeof(CreateSalaCommandHandler).Assembly));
            liteBus.AddQueryModule(module => module.RegisterFromAssembly(typeof(GetAllSalasQueryHandler).Assembly));
        });

        return services;
    }
}
