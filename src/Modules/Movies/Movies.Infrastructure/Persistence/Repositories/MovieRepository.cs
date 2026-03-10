using Abstractions.Repositories;
using Movies.Application.Contracts;
using Movies.Domain.Entities;

namespace Movies.Infrastructure.Persistence.Repositories;

public class MovieRepository : GenericRepository<Movie, MoviesDbContext>, IMovieRepository
{
    public MovieRepository(MoviesDbContext dbContext) : base(dbContext)
    {
    }
    
    // Implementaciones de métodos específicos para Movie
    // Ejemplo de cómo agregar métodos personalizados:
    
    // public async Task<List<Movie>> GetMoviesByGenreAsync(string genre, CancellationToken cancellationToken = default)
    // {
    //     return await _dbSet
    //         .Where(m => m.Genre == genre)
    //         .ToListAsync(cancellationToken);
    // }
}
