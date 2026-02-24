using Movies.Domain.Entities;

namespace Movies.Application.Contracts;

public interface IMovieRepository
{
    Task<List<Movie>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Movie movie, CancellationToken cancellationToken = default);
}
