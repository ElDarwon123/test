using Asientos.Application.DTOs;

namespace Asientos.Application.Queries.GetAllAsientos;

public record GetAllAsientosQuery : IQuery<List<AsientoDto>>;
