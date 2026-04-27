using Horarios.Application.Commands.CreateHorario;
using Horarios.Application.Contracts;
using Horarios.Application.Queries.GetAllHorarios;
using Horarios.Infrastructure.Persistence.Repositories;
using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Horarios.Infrastructure;

public static class HorariosModule
{
    public static IServiceCollection AddHorariosModule(this IServiceCollection services)
    {
        services.AddScoped<IHorarioRepository, HorarioRepository>();

        services.AddLiteBus(liteBus =>
        {
            liteBus.AddCommandModule(module => module.RegisterFromAssembly(typeof(CreateHorarioCommandHandler).Assembly));
            liteBus.AddQueryModule(module => module.RegisterFromAssembly(typeof(GetAllHorariosQueryHandler).Assembly));
        });

        return services;
    }
}
