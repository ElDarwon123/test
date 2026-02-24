using LiteBus.Queries.Abstractions;
using Movies.Application.Contracts;
using Movies.Application.DTOs;

namespace Movies.Application.Queries.GetAllMovies;

public class GetAllMoviesQueryHandler : IQueryHandler<GetAllMoviesQuery, List<MovieDto>>
{
    private readonly IMovieRepository _movieRepository;

    public GetAllMoviesQueryHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<List<MovieDto>> HandleAsync(GetAllMoviesQuery query, CancellationToken cancellationToken = default)
    {
        var movies = await _movieRepository.GetAllAsync(cancellationToken);

        return movies
            .Select(m => new MovieDto(m.Id, m.Title, m.Description, m.Year, m.Genre))
            .ToList();
    }
}
