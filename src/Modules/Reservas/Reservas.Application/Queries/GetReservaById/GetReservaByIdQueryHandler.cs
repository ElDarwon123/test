using LiteBus.Queries.Abstractions;
using Reservas.Application.Contracts;
using Reservas.Application.DTOs;

namespace Reservas.Application.Queries.GetReservaById;

public class GetReservaByIdQueryHandler : IQueryHandler<GetReservaByIdQuery, ReservaDto?>
{
    private readonly IReservaRepository _reservaRepository;

    public GetReservaByIdQueryHandler(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public async Task<ReservaDto?> HandleAsync(GetReservaByIdQuery query, CancellationToken cancellationToken = default)
    {
        var reserva = await _reservaRepository.GetByIdAsync(query.Id, cancellationToken);
        if (reserva == null || !reserva.Active)
            return null;
        return new ReservaDto(reserva.IdReserva, reserva.IdHorario, reserva.NombreCliente, reserva.EmailCliente, reserva.FechaReserva, reserva.Total, reserva.Estado, reserva.Active);
    }
}
