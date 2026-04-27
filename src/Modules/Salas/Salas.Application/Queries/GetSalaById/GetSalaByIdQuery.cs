using LiteBus.Queries.Abstractions;
using Salas.Application.DTOs;

namespace Salas.Application.Queries.GetSalaById;

public record GetSalaByIdQuery(int Id) : IQuery<SalaDto?>;
