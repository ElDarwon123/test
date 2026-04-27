using Salas.Application.DTOs;

namespace Salas.Application.Queries.GetAllSalas;

public record GetAllSalasQuery : IQuery<List<SalaDto>>;
