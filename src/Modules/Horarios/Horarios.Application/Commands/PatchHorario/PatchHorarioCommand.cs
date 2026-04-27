using LiteBus.Commands.Abstractions;

namespace Horarios.Application.Commands.PatchHorario;

public record PatchHorarioCommand(int IdHorario, int? IdPelicula, int? IdSala, DateOnly? Fecha, string? Hora, string? Idioma, string? Estado) : ICommand;
