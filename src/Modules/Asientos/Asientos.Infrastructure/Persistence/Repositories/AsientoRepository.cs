using Abstractions.Repositories;
using Asientos.Application.Contracts;
using Asientos.Domain.Entities;
using Movies.Infrastructure.Persistence;

namespace Asientos.Infrastructure.Persistence.Repositories;

public class AsientoRepository : GenericRepository<Asiento, MoviesDbContext>, IAsientoRepository
{
    public AsientoRepository(MoviesDbContext dbContext) : base(dbContext)
    {
    }
}
