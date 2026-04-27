using LiteBus.Commands.Abstractions;
using Movies.Application.Contracts;

namespace Movies.Application.Commands.DeleteMovie;

public class DeleteMovieCommandHandler : ICommandHandler<DeleteMovieCommand>
{
    private readonly IPeliculaRepository _peliculaRepository;

    public DeleteMovieCommandHandler(IPeliculaRepository peliculaRepository)
    {
        _peliculaRepository = peliculaRepository;
    }

    public async Task HandleAsync(DeleteMovieCommand command, CancellationToken cancellationToken = default)
    {
        await _peliculaRepository.SoftDeleteAsync(command.Id, cancellationToken);
    }
}
