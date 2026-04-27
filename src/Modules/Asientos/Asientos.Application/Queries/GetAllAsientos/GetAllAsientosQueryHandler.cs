using Asientos.Application.Contracts;
using Asientos.Application.DTOs;

namespace Asientos.Application.Queries.GetAllAsientos;

public class GetAllAsientosQueryHandler : IQueryHandler<GetAllAsientosQuery, List<AsientoDto>>
{
    private readonly IAsientoRepository _asientoRepository;

    public GetAllAsientosQueryHandler(IAsientoRepository asientoRepository)
    {
        _asientoRepository = asientoRepository;
    }

    public async Task<List<AsientoDto>> HandleAsync(GetAllAsientosQuery query, CancellationToken cancellationToken = default)
    {
        var asientos = await _asientoRepository.GetAllAsync(cancellationToken);

        return asientos
            .Where(a => a.Active)
            .Select(a => new AsientoDto(a.IdAsiento, a.IdSala, a.Fila, a.Numero, a.TipoAsiento, a.Estado, a.Active))
            .ToList();
    }
}
