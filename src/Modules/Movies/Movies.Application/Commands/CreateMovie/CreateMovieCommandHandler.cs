using LiteBus.Commands.Abstractions;
using Movies.Application.Contracts;
using Movies.Domain.Entities;

namespace Movies.Application.Commands.CreateMovie;

public class CreateMovieCommandHandler : ICommandHandler<CreateMovieCommand>
{
    private readonly IMovieRepository _movieRepository;

    public CreateMovieCommandHandler(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task HandleAsync(CreateMovieCommand command, CancellationToken cancellationToken = default)
    {
        var movie = new Movie
        {
            Id = Guid.NewGuid(),
            Title = command.Title,
            Description = command.Description,
            Year = command.Year,
            Genre = command.Genre
        };

        await _movieRepository.AddAsync(movie, cancellationToken);
    }
}
