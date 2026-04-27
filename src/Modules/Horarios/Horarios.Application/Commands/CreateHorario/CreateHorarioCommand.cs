namespace Horarios.Application.Commands.CreateHorario;

public record CreateHorarioCommand(
    int IdPelicula,
    int IdSala,
    DateOnly Fecha,
    string Hora,
    string Idioma,
    string Estado = "programado") : ICommand;
