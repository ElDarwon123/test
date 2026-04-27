using LiteBus.Commands.Abstractions;
using Reservas.Application.Contracts;

namespace Reservas.Application.Commands.PatchReserva;

public class PatchReservaCommandHandler : ICommandHandler<PatchReservaCommand>
{
    private readonly IReservaRepository _reservaRepository;

    public PatchReservaCommandHandler(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public async Task HandleAsync(PatchReservaCommand command, CancellationToken cancellationToken = default)
    {
        var reserva = await _reservaRepository.GetByIdAsync(command.IdReserva, cancellationToken);
        if (reserva == null || !reserva.Active)
            return;

        if (command.IdHorario.HasValue) reserva.IdHorario = command.IdHorario.Value;
        if (command.NombreCliente != null) reserva.NombreCliente = command.NombreCliente;
        if (command.EmailCliente != null) reserva.EmailCliente = command.EmailCliente;
        if (command.FechaReserva.HasValue) reserva.FechaReserva = command.FechaReserva.Value;
        if (command.Total.HasValue) reserva.Total = command.Total.Value;
        if (command.Estado != null) reserva.Estado = command.Estado;

        await _reservaRepository.UpdateAsync(reserva, cancellationToken);
    }
}
