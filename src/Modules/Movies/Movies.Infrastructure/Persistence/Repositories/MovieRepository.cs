using Microsoft.EntityFrameworkCore;
using Movies.Application.Contracts;
using Movies.Domain.Entities;

namespace Movies.Infrastructure.Persistence.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly MoviesDbContext _dbContext;

    public MovieRepository(MoviesDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _dbContext.Movies.ToListAsync(cancellationToken);
    }

    public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Movies.FindAsync([id], cancellationToken);
    }

    public async Task AddAsync(Movie movie, CancellationToken cancellationToken = default)
    {
        await _dbContext.Movies.AddAsync(movie, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
