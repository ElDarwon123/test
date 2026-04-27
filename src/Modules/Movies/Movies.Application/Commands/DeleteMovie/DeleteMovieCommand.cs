using LiteBus.Commands.Abstractions;

namespace Movies.Application.Commands.DeleteMovie;

public record DeleteMovieCommand(int Id) : ICommand;
