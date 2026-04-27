using LiteBus.Queries.Abstractions;
using Movies.Application.Contracts;
using Movies.Application.DTOs;

namespace Movies.Application.Queries.GetMovieById;

public class GetMovieByIdQueryHandler : IQueryHandler<GetMovieByIdQuery, PeliculaDto?>
{
    private readonly IPeliculaRepository _peliculaRepository;

    public GetMovieByIdQueryHandler(IPeliculaRepository peliculaRepository)
    {
        _peliculaRepository = peliculaRepository;
    }

    public async Task<PeliculaDto?> HandleAsync(GetMovieByIdQuery query, CancellationToken cancellationToken = default)
    {
        var pelicula = await _peliculaRepository.GetByIdAsync(query.Id, cancellationToken);
        if (pelicula == null || !pelicula.Active)
            return null;
        return new PeliculaDto(pelicula.IdPelicula, pelicula.Titulo, pelicula.Genero, pelicula.DuracionMin, pelicula.Clasificacion, pelicula.FechaEstreno, pelicula.Estado, pelicula.Active);
    }
}
