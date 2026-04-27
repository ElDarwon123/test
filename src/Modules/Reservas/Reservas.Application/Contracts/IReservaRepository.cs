using Abstractions.Repositories;
using Reservas.Domain.Entities;

namespace Reservas.Application.Contracts;

public interface IReservaRepository : IGenericRepository<Reserva>
{
}
