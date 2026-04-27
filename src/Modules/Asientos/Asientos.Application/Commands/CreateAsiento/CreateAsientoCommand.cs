namespace Asientos.Application.Commands.CreateAsiento;

public record CreateAsientoCommand(
    int IdSala,
    string Fila,
    int Numero,
    string TipoAsiento,
    string Estado = "disponible") : ICommand;
