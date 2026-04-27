using Abstractions.Repositories;
using Asientos.Domain.Entities;

namespace Asientos.Application.Contracts;

public interface IAsientoRepository : IGenericRepository<Asiento>
{
}
