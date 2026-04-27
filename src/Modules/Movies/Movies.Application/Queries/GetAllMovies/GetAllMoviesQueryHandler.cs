using LiteBus.Queries.Abstractions;
using Movies.Application.Contracts;
using Movies.Application.DTOs;

namespace Movies.Application.Queries.GetAllMovies;

public class GetAllMoviesQueryHandler : IQueryHandler<GetAllMoviesQuery, List<PeliculaDto>>
{
    private readonly IPeliculaRepository _peliculaRepository;

    public GetAllMoviesQueryHandler(IPeliculaRepository peliculaRepository)
    {
        _peliculaRepository = peliculaRepository;
    }

    public async Task<List<PeliculaDto>> HandleAsync(GetAllMoviesQuery query, CancellationToken cancellationToken = default)
    {
        var peliculas = await _peliculaRepository.GetAllAsync(cancellationToken);

        return peliculas
            .Where(p => p.Active)
            .Select(p => new PeliculaDto(
                p.IdPelicula,
                p.Titulo,
                p.Genero,
                p.DuracionMin,
                p.Clasificacion,
                p.FechaEstreno,
                p.Estado,
                p.Active))
            .ToList();
    }
}
