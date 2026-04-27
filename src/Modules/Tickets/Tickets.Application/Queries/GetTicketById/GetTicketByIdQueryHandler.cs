using LiteBus.Queries.Abstractions;
using Tickets.Application.Contracts;
using Tickets.Application.DTOs;

namespace Tickets.Application.Queries.GetTicketById;

public class GetTicketByIdQueryHandler : IQueryHandler<GetTicketByIdQuery, TicketDto?>
{
    private readonly ITicketRepository _ticketRepository;

    public GetTicketByIdQueryHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task<TicketDto?> HandleAsync(GetTicketByIdQuery query, CancellationToken cancellationToken = default)
    {
        var ticket = await _ticketRepository.GetByIdAsync(query.Id, cancellationToken);
        if (ticket == null || !ticket.Active)
            return null;
        return new TicketDto(ticket.IdTicket, ticket.IdReserva, ticket.IdAsiento, ticket.CodigoTicket, ticket.Precio, ticket.FechaEmision, ticket.Estado, ticket.Active);
    }
}
