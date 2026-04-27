using LiteBus.Commands.Abstractions;
using Horarios.Application.Contracts;

namespace Horarios.Application.Commands.DeleteHorario;

public class DeleteHorarioCommandHandler : ICommandHandler<DeleteHorarioCommand>
{
    private readonly IHorarioRepository _horarioRepository;

    public DeleteHorarioCommandHandler(IHorarioRepository horarioRepository)
    {
        _horarioRepository = horarioRepository;
    }

    public async Task HandleAsync(DeleteHorarioCommand command, CancellationToken cancellationToken = default)
    {
        await _horarioRepository.SoftDeleteAsync(command.Id, cancellationToken);
    }
}
