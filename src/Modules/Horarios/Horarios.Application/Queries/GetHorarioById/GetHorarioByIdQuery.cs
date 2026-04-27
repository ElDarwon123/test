using LiteBus.Queries.Abstractions;
using Horarios.Application.DTOs;

namespace Horarios.Application.Queries.GetHorarioById;

public record GetHorarioByIdQuery(int Id) : IQuery<HorarioDto?>;
