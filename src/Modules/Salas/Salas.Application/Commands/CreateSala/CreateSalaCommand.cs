namespace Salas.Application.Commands.CreateSala;

public record CreateSalaCommand(
    string Nombre,
    int Capacidad,
    string TipoSala,
    string? Ubicacion,
    string Estado = "activa") : ICommand;
