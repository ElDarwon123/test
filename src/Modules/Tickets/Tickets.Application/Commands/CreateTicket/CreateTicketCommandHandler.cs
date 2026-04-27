using Tickets.Application.Contracts;
using Tickets.Domain.Entities;

namespace Tickets.Application.Commands.CreateTicket;

public class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand>
{
    private readonly ITicketRepository _ticketRepository;

    public CreateTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task HandleAsync(CreateTicketCommand command, CancellationToken cancellationToken = default)
    {
        var ticket = new Ticket
        {
            IdReserva = command.IdReserva,
            IdAsiento = command.IdAsiento,
            CodigoTicket = command.CodigoTicket,
            Precio = command.Precio,
            FechaEmision = DateTime.UtcNow,
            Estado = command.Estado
        };

        await _ticketRepository.AddAsync(ticket, cancellationToken);
    }
}
