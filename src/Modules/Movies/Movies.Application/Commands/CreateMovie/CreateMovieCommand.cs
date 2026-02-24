using LiteBus.Commands.Abstractions;

namespace Movies.Application.Commands.CreateMovie;

public record CreateMovieCommand(string Title, string Description, int Year, string Genre) : ICommand;
