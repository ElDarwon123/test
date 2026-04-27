using Abstractions.Repositories;
using Movies.Infrastructure.Persistence;
using Reservas.Application.Contracts;
using Reservas.Domain.Entities;

namespace Reservas.Infrastructure.Persistence.Repositories;

public class ReservaRepository : GenericRepository<Reserva, MoviesDbContext>, IReservaRepository
{
    public ReservaRepository(MoviesDbContext dbContext) : base(dbContext)
    {
    }
}
