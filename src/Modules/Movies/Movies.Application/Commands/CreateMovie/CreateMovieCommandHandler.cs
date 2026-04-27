using LiteBus.Commands.Abstractions;
using Movies.Application.Contracts;
using Movies.Domain.Entities;

namespace Movies.Application.Commands.CreateMovie;

public class CreateMovieCommandHandler : ICommandHandler<CreateMovieCommand>
{
    private readonly IPeliculaRepository _peliculaRepository;

    public CreateMovieCommandHandler(IPeliculaRepository peliculaRepository)
    {
        _peliculaRepository = peliculaRepository;
    }

    public async Task HandleAsync(CreateMovieCommand command, CancellationToken cancellationToken = default)
    {
        var pelicula = new Pelicula
        {
            Titulo = command.Titulo,
            Genero = command.Genero,
            DuracionMin = command.DuracionMin,
            Clasificacion = command.Clasificacion,
            FechaEstreno = command.FechaEstreno,
            Estado = command.Estado
        };

        await _peliculaRepository.AddAsync(pelicula, cancellationToken);
    }
}
