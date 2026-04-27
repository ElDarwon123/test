using LiteBus.Queries.Abstractions;
using Salas.Application.Contracts;
using Salas.Application.DTOs;

namespace Salas.Application.Queries.GetSalaById;

public class GetSalaByIdQueryHandler : IQueryHandler<GetSalaByIdQuery, SalaDto?>
{
    private readonly ISalaRepository _salaRepository;

    public GetSalaByIdQueryHandler(ISalaRepository salaRepository)
    {
        _salaRepository = salaRepository;
    }

    public async Task<SalaDto?> HandleAsync(GetSalaByIdQuery query, CancellationToken cancellationToken = default)
    {
        var sala = await _salaRepository.GetByIdAsync(query.Id, cancellationToken);
        if (sala == null || !sala.Active)
            return null;
        return new SalaDto(sala.IdSala, sala.Nombre, sala.Capacidad, sala.TipoSala, sala.Ubicacion, sala.Estado, sala.Active);
    }
}
