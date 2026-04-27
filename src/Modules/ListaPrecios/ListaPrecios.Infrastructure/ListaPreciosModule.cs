using ListaPrecios.Application.Commands.CreateListaPrecio;
using ListaPrecios.Application.Contracts;
using ListaPrecios.Application.Queries.GetAllListaPrecios;
using ListaPrecios.Infrastructure.Persistence.Repositories;
using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace ListaPrecios.Infrastructure;

public static class ListaPreciosModule
{
    public static IServiceCollection AddListaPreciosModule(this IServiceCollection services)
    {
        services.AddScoped<IListaPrecioRepository, ListaPrecioRepository>();

        services.AddLiteBus(liteBus =>
        {
            liteBus.AddCommandModule(module => module.RegisterFromAssembly(typeof(CreateListaPrecioCommandHandler).Assembly));
            liteBus.AddQueryModule(module => module.RegisterFromAssembly(typeof(GetAllListaPreciosQueryHandler).Assembly));
        });

        return services;
    }
}
