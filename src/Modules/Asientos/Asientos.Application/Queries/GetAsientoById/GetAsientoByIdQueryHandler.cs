using LiteBus.Queries.Abstractions;
using Asientos.Application.Contracts;
using Asientos.Application.DTOs;

namespace Asientos.Application.Queries.GetAsientoById;

public class GetAsientoByIdQueryHandler : IQueryHandler<GetAsientoByIdQuery, AsientoDto?>
{
    private readonly IAsientoRepository _asientoRepository;

    public GetAsientoByIdQueryHandler(IAsientoRepository asientoRepository)
    {
        _asientoRepository = asientoRepository;
    }

    public async Task<AsientoDto?> HandleAsync(GetAsientoByIdQuery query, CancellationToken cancellationToken = default)
    {
        var asiento = await _asientoRepository.GetByIdAsync(query.Id, cancellationToken);
        if (asiento == null || !asiento.Active)
            return null;
        return new AsientoDto(asiento.IdAsiento, asiento.IdSala, asiento.Fila, asiento.Numero, asiento.TipoAsiento, asiento.Estado, asiento.Active);
    }
}
