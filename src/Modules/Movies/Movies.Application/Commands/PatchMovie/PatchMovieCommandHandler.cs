using LiteBus.Commands.Abstractions;
using Movies.Application.Contracts;

namespace Movies.Application.Commands.PatchMovie;

public class PatchMovieCommandHandler : ICommandHandler<PatchMovieCommand>
{
    private readonly IPeliculaRepository _peliculaRepository;

    public PatchMovieCommandHandler(IPeliculaRepository peliculaRepository)
    {
        _peliculaRepository = peliculaRepository;
    }

    public async Task HandleAsync(PatchMovieCommand command, CancellationToken cancellationToken = default)
    {
        var pelicula = await _peliculaRepository.GetByIdAsync(command.IdPelicula, cancellationToken);
        if (pelicula == null || !pelicula.Active)
            return;

        if (command.Titulo != null) pelicula.Titulo = command.Titulo;
        if (command.Genero != null) pelicula.Genero = command.Genero;
        if (command.DuracionMin.HasValue) pelicula.DuracionMin = command.DuracionMin.Value;
        if (command.Clasificacion != null) pelicula.Clasificacion = command.Clasificacion;
        if (command.FechaEstreno.HasValue) pelicula.FechaEstreno = command.FechaEstreno.Value;
        if (command.Estado != null) pelicula.Estado = command.Estado;

        await _peliculaRepository.UpdateAsync(pelicula, cancellationToken);
    }
}
