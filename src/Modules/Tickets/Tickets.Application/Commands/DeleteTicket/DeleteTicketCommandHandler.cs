using LiteBus.Commands.Abstractions;
using Tickets.Application.Contracts;

namespace Tickets.Application.Commands.DeleteTicket;

public class DeleteTicketCommandHandler : ICommandHandler<DeleteTicketCommand>
{
    private readonly ITicketRepository _ticketRepository;

    public DeleteTicketCommandHandler(ITicketRepository ticketRepository)
    {
        _ticketRepository = ticketRepository;
    }

    public async Task HandleAsync(DeleteTicketCommand command, CancellationToken cancellationToken = default)
    {
        await _ticketRepository.SoftDeleteAsync(command.Id, cancellationToken);
    }
}
