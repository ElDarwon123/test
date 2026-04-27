using LiteBus.Commands.Abstractions;
using Salas.Application.Contracts;

namespace Salas.Application.Commands.DeleteSala;

public class DeleteSalaCommandHandler : ICommandHandler<DeleteSalaCommand>
{
    private readonly ISalaRepository _salaRepository;

    public DeleteSalaCommandHandler(ISalaRepository salaRepository)
    {
        _salaRepository = salaRepository;
    }

    public async Task HandleAsync(DeleteSalaCommand command, CancellationToken cancellationToken = default)
    {
        await _salaRepository.SoftDeleteAsync(command.Id, cancellationToken);
    }
}
