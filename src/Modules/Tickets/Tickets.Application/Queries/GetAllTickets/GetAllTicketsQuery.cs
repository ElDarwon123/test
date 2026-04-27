using Tickets.Application.DTOs;

namespace Tickets.Application.Queries.GetAllTickets;

public record GetAllTicketsQuery : IQuery<List<TicketDto>>;
