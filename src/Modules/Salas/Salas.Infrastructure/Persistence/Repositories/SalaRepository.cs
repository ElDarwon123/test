using Abstractions.Repositories;
using Movies.Infrastructure.Persistence;
using Salas.Application.Contracts;
using Salas.Domain.Entities;

namespace Salas.Infrastructure.Persistence.Repositories;

public class SalaRepository : GenericRepository<Sala, MoviesDbContext>, ISalaRepository
{
    public SalaRepository(MoviesDbContext dbContext) : base(dbContext)
    {
    }
}
