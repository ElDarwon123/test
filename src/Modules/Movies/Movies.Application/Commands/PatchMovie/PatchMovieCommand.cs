using LiteBus.Commands.Abstractions;

namespace Movies.Application.Commands.PatchMovie;

public record PatchMovieCommand(int IdPelicula, string? Titulo, string? Genero, int? DuracionMin, string? Clasificacion, DateOnly? FechaEstreno, string? Estado) : ICommand;
