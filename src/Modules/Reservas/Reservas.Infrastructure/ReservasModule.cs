using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;
using Reservas.Application.Commands.CreateReserva;
using Reservas.Application.Contracts;
using Reservas.Application.Queries.GetAllReservas;
using Reservas.Infrastructure.Persistence.Repositories;

namespace Reservas.Infrastructure;

public static class ReservasModule
{
    public static IServiceCollection AddReservasModule(this IServiceCollection services)
    {
        services.AddScoped<IReservaRepository, ReservaRepository>();

        services.AddLiteBus(liteBus =>
        {
            liteBus.AddCommandModule(module => module.RegisterFromAssembly(typeof(CreateReservaCommandHandler).Assembly));
            liteBus.AddQueryModule(module => module.RegisterFromAssembly(typeof(GetAllReservasQueryHandler).Assembly));
        });

        return services;
    }
}
