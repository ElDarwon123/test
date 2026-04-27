using Tickets.Application.Contracts;
using Tickets.Application.DTOs;

namespace Tickets.Application.Queries.GetAllTickets;

public class GetAllTicketsQueryHandler : IQueryHandler<GetAllTicketsQuery, List<TicketDto>>
{
    private readonly ITicketRepository _ticketRepository;

    public GetAllTicketsQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<List<TicketDto>> HandleAsync(GetAllTicketsQuery query, CancellationToken cancellationToken = default)
    {
        var tickets = await _ticketRepository.GetAllAsync(cancellationToken);

        return tickets
            .Where(t => t.Active)
            .Select(t => new TicketDto(t.IdTicket, t.IdReserva, t.IdAsiento, t.CodigoTicket, t.Precio, t.FechaEmision, t.Estado, t.Active))
            .ToList();
    }
}
