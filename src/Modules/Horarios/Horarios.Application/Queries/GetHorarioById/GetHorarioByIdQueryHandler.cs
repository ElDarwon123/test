using LiteBus.Queries.Abstractions;
using Horarios.Application.Contracts;
using Horarios.Application.DTOs;

namespace Horarios.Application.Queries.GetHorarioById;

public class GetHorarioByIdQueryHandler : IQueryHandler<GetHorarioByIdQuery, HorarioDto?>
{
    private readonly IHorarioRepository _horarioRepository;

    public GetHorarioByIdQueryHandler(IHorarioRepository horarioRepository)
    {
        _horarioRepository = horarioRepository;
    }

    public async Task<HorarioDto?> HandleAsync(GetHorarioByIdQuery query, CancellationToken cancellationToken = default)
    {
        var horario = await _horarioRepository.GetByIdAsync(query.Id, cancellationToken);
        if (horario == null || !horario.Active)
            return null;
        return new HorarioDto(horario.IdHorario, horario.IdPelicula, horario.IdSala, horario.Fecha, horario.Hora, horario.Idioma, horario.Estado, horario.Active);
    }
}
