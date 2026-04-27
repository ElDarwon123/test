using LiteBus.Commands.Abstractions;
using Asientos.Application.Contracts;

namespace Asientos.Application.Commands.DeleteAsiento;

public class DeleteAsientoCommandHandler : ICommandHandler<DeleteAsientoCommand>
{
    private readonly IAsientoRepository _asientoRepository;

    public DeleteAsientoCommandHandler(IAsientoRepository asientoRepository)
    {
        _asientoRepository = asientoRepository;
    }

    public async Task HandleAsync(DeleteAsientoCommand command, CancellationToken cancellationToken = default)
    {
        await _asientoRepository.SoftDeleteAsync(command.Id, cancellationToken);
    }
}
