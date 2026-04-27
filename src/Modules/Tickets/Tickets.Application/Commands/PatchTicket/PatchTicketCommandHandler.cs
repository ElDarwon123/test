using LiteBus.Commands.Abstractions;
using Tickets.Application.Contracts;

namespace Tickets.Application.Commands.PatchTicket;

public class PatchTicketCommandHandler : ICommandHandler<PatchTicketCommand>
{
    private readonly ITicketRepository _ticketRepository;

    public PatchTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task HandleAsync(PatchTicketCommand command, CancellationToken cancellationToken = default)
    {
        var ticket = await _ticketRepository.GetByIdAsync(command.IdTicket, cancellationToken);
        if (ticket == null || !ticket.Active)
            return;

        if (command.IdReserva.HasValue) ticket.IdReserva = command.IdReserva.Value;
        if (command.IdAsiento.HasValue) ticket.IdAsiento = command.IdAsiento.Value;
        if (command.CodigoTicket != null) ticket.CodigoTicket = command.CodigoTicket;
        if (command.Precio.HasValue) ticket.Precio = command.Precio.Value;
        if (command.FechaEmision.HasValue) ticket.FechaEmision = command.FechaEmision.Value;
        if (command.Estado != null) ticket.Estado = command.Estado;

        await _ticketRepository.UpdateAsync(ticket, cancellationToken);
    }
}
