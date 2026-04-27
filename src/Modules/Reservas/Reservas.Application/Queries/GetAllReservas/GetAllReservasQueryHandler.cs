using Reservas.Application.Contracts;
using Reservas.Application.DTOs;

namespace Reservas.Application.Queries.GetAllReservas;

public class GetAllReservasQueryHandler : IQueryHandler<GetAllReservasQuery, List<ReservaDto>>
{
    private readonly IReservaRepository _reservaRepository;

    public GetAllReservasQueryHandler(IReservaRepository reservaRepository)
    {
        _reservaRepository = reservaRepository;
    }

    public async Task<List<ReservaDto>> HandleAsync(GetAllReservasQuery query, CancellationToken cancellationToken = default)
    {
        var reservas = await _reservaRepository.GetAllAsync(cancellationToken);

        return reservas
            .Where(r => r.Active)
            .Select(r => new ReservaDto(r.IdReserva, r.IdHorario, r.NombreCliente, r.EmailCliente, r.FechaReserva, r.Total, r.Estado, r.Active))
            .ToList();
    }
}
