using LiteBus.Commands;
using LiteBus.Extensions.Microsoft.DependencyInjection;
using LiteBus.Queries;
using Microsoft.Extensions.DependencyInjection;
using Tickets.Application.Commands.CreateTicket;
using Tickets.Application.Contracts;
using Tickets.Application.Queries.GetAllTickets;
using Tickets.Infrastructure.Persistence.Repositories;

namespace Tickets.Infrastructure;

public static class TicketsModule
{
    public static IServiceCollection AddTicketsModule(this IServiceCollection services)
    {
        services.AddScoped<ITicketRepository, TicketRepository>();

        services.AddLiteBus(liteBus =>
        {
            liteBus.AddCommandModule(module => module.RegisterFromAssembly(typeof(CreateTicketCommandHandler).Assembly));
            liteBus.AddQueryModule(module => module.RegisterFromAssembly(typeof(GetAllTicketsQueryHandler).Assembly));
        });

        return services;
    }
}
