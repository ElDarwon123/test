using Reservas.Application.Contracts;
using Reservas.Domain.Entities;

namespace Reservas.Application.Commands.CreateReserva;

public class CreateReservaCommandHandler : ICommandHandler<CreateReservaCommand>
{
    private readonly IReservaRepository _reservaRepository;

    public CreateReservaCommandHandler(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public async Task HandleAsync(CreateReservaCommand command, CancellationToken cancellationToken = default)
    {
        var reserva = new Reserva
        {
            IdHorario = command.IdHorario,
            NombreCliente = command.NombreCliente,
            EmailCliente = command.EmailCliente,
            FechaReserva = DateTime.UtcNow,
            Total = command.Total,
            Estado = command.Estado
        };

        await _reservaRepository.AddAsync(reserva, cancellationToken);
    }
}
