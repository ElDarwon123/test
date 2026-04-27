using Abstractions.Repositories;
using Movies.Application.Contracts;
using Movies.Domain.Entities;

namespace Movies.Infrastructure.Persistence.Repositories;

public class PeliculaRepository : GenericRepository<Pelicula, MoviesDbContext>, IPeliculaRepository
{
    public PeliculaRepository(MoviesDbContext dbContext) : base(dbContext)
    {
    }
}