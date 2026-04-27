using Horarios.Application.Contracts;
using Horarios.Application.DTOs;

namespace Horarios.Application.Queries.GetAllHorarios;

public class GetAllHorariosQueryHandler : IQueryHandler<GetAllHorariosQuery, List<HorarioDto>>
{
    private readonly IHorarioRepository _horarioRepository;

    public GetAllHorariosQueryHandler(IHorarioRepository horarioRepository)
    {
        _horarioRepository = horarioRepository;
    }

    public async Task<List<HorarioDto>> HandleAsync(GetAllHorariosQuery query, CancellationToken cancellationToken = default)
    {
        var horarios = await _horarioRepository.GetAllAsync(cancellationToken);

        return horarios
            .Where(h => h.Active)
            .Select(h => new HorarioDto(h.IdHorario, h.IdPelicula, h.IdSala, h.Fecha, h.Hora, h.Idioma, h.Estado, h.Active))
            .ToList();
    }
}
