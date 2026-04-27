using LiteBus.Queries.Abstractions;
using Movies.Application.DTOs;

namespace Movies.Application.Queries.GetMovieById;

public record GetMovieByIdQuery(int Id) : IQuery<PeliculaDto?>;
