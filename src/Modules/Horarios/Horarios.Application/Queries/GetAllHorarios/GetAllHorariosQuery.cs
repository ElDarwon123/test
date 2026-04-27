using Horarios.Application.DTOs;

namespace Horarios.Application.Queries.GetAllHorarios;

public record GetAllHorariosQuery : IQuery<List<HorarioDto>>;
