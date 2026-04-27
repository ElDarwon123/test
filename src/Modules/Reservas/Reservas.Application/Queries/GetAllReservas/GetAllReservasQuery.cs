using Reservas.Application.DTOs;

namespace Reservas.Application.Queries.GetAllReservas;

public record GetAllReservasQuery : IQuery<List<ReservaDto>>;
