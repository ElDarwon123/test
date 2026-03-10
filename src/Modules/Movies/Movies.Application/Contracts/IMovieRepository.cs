using Abstractions.Repositories;
using Movies.Domain.Entities;

namespace Movies.Application.Contracts;

public interface IMovieRepository : IGenericRepository<Movie>
{
    // Métodos específicos para Movie que pueden ser implementados en el futuro
    // Ejemplo:
    // Task<List<Movie>> GetMoviesByGenreAsync(string genre, CancellationToken cancellationToken = default);
    // Task<List<Movie>> GetMoviesByYearAsync(int year, CancellationToken cancellationToken = default);
    // Task<Movie?> GetMovieByTitleAsync(string title, CancellationToken cancellationToken = default);
}
