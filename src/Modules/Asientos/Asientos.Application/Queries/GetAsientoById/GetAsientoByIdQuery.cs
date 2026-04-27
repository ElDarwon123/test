using LiteBus.Queries.Abstractions;
using Asientos.Application.DTOs;

namespace Asientos.Application.Queries.GetAsientoById;

public record GetAsientoByIdQuery(int Id) : IQuery<AsientoDto?>;
