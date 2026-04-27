using LiteBus.Queries.Abstractions;
using Tickets.Application.DTOs;

namespace Tickets.Application.Queries.GetTicketById;

public record GetTicketByIdQuery(int Id) : IQuery<TicketDto?>;
