using LiteBus.Commands.Abstractions;

namespace Movies.Application.Commands.CreateMovie;

public record CreateMovieCommand(
    string Titulo,
    string Genero,
    int DuracionMin,
    string Clasificacion,
    DateOnly? FechaEstreno,
    string Estado = "activa") : ICommand;
