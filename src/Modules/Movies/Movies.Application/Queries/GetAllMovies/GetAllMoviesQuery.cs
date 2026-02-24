using LiteBus.Queries.Abstractions;
using Movies.Application.DTOs;

namespace Movies.Application.Queries.GetAllMovies;

public record GetAllMoviesQuery : IQuery<List<MovieDto>>;
