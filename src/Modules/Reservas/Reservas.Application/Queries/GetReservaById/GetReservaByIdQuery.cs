using LiteBus.Queries.Abstractions;
using Reservas.Application.DTOs;

namespace Reservas.Application.Queries.GetReservaById;

public record GetReservaByIdQuery(int Id) : IQuery<ReservaDto?>;
