using LiteBus.Commands.Abstractions;
using Asientos.Application.Contracts;

namespace Asientos.Application.Commands.PatchAsiento;

public class PatchAsientoCommandHandler : ICommandHandler<PatchAsientoCommand>
{
    private readonly IAsientoRepository _asientoRepository;

    public PatchAsientoCommandHandler(IAsientoRepository asientoRepository)
    {
        _asientoRepository = asientoRepository;
    }

    public async Task HandleAsync(PatchAsientoCommand command, CancellationToken cancellationToken = default)
    {
        var asiento = await _asientoRepository.GetByIdAsync(command.IdAsiento, cancellationToken);
        if (asiento == null || !asiento.Active)
            return;

        if (command.IdSala.HasValue) asiento.IdSala = command.IdSala.Value;
        if (command.Fila != null) asiento.Fila = command.Fila;
        if (command.Numero.HasValue) asiento.Numero = command.Numero.Value;
        if (command.TipoAsiento != null) asiento.TipoAsiento = command.TipoAsiento;
        if (command.Estado != null) asiento.Estado = command.Estado;

        await _asientoRepository.UpdateAsync(asiento, cancellationToken);
    }
}
