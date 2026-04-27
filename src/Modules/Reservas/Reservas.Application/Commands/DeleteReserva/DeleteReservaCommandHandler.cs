using LiteBus.Commands.Abstractions;
using Reservas.Application.Contracts;

namespace Reservas.Application.Commands.DeleteReserva;

public class DeleteReservaCommandHandler : ICommandHandler<DeleteReservaCommand>
{
    private readonly IReservaRepository _reservaRepository;

    public DeleteReservaCommandHandler(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public async Task HandleAsync(DeleteReservaCommand command, CancellationToken cancellationToken = default)
    {
        await _reservaRepository.SoftDeleteAsync(command.Id, cancellationToken);
    }
}
