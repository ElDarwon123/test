using Salas.Application.Contracts;
using Salas.Domain.Entities;

namespace Salas.Application.Commands.CreateSala;

public class CreateSalaCommandHandler : ICommandHandler<CreateSalaCommand>
{
    private readonly ISalaRepository _salaRepository;

    public CreateSalaCommandHandler(ISalaRepository salaRepository)
    {
        _salaRepository = salaRepository;
    }

    public async Task HandleAsync(CreateSalaCommand command, CancellationToken cancellationToken = default)
    {
        var sala = new Sala
        {
            Nombre = command.Nombre,
            Capacidad = command.Capacidad,
            TipoSala = command.TipoSala,
            Ubicacion = command.Ubicacion,
            Estado = command.Estado
        };

        await _salaRepository.AddAsync(sala, cancellationToken);
    }
}
