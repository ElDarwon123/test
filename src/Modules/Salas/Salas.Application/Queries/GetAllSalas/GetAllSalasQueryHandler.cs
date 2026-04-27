using Salas.Application.Contracts;
using Salas.Application.DTOs;

namespace Salas.Application.Queries.GetAllSalas;

public class GetAllSalasQueryHandler : IQueryHandler<GetAllSalasQuery, List<SalaDto>>
{
    private readonly ISalaRepository _salaRepository;

    public GetAllSalasQueryHandler(ISalaRepository salaRepository)
    {
        _salaRepository = salaRepository;
    }

    public async Task<List<SalaDto>> HandleAsync(GetAllSalasQuery query, CancellationToken cancellationToken = default)
    {
        var salas = await _salaRepository.GetAllAsync(cancellationToken);

        return salas
            .Where(s => s.Active)
            .Select(s => new SalaDto(s.IdSala, s.Nombre, s.Capacidad, s.TipoSala, s.Ubicacion, s.Estado, s.Active))
            .ToList();
    }
}
