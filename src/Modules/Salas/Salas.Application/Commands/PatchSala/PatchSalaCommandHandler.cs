using LiteBus.Commands.Abstractions;
using Salas.Application.Contracts;

namespace Salas.Application.Commands.PatchSala;

public class PatchSalaCommandHandler : ICommandHandler<PatchSalaCommand>
{
    private readonly ISalaRepository _salaRepository;

    public PatchSalaCommandHandler(ISalaRepository salaRepository)
    {
        _salaRepository = salaRepository;
    }

    public async Task HandleAsync(PatchSalaCommand command, CancellationToken cancellationToken = default)
    {
        var sala = await _salaRepository.GetByIdAsync(command.IdSala, cancellationToken);
        if (sala == null || !sala.Active)
            return;

        if (command.Nombre != null) sala.Nombre = command.Nombre;
        if (command.Capacidad.HasValue) sala.Capacidad = command.Capacidad.Value;
        if (command.TipoSala != null) sala.TipoSala = command.TipoSala;
        if (command.Ubicacion != null) sala.Ubicacion = command.Ubicacion;
        if (command.Estado != null) sala.Estado = command.Estado;

        await _salaRepository.UpdateAsync(sala, cancellationToken);
    }
}
