namespace Reservas.Application.Commands.CreateReserva;

public record CreateReservaCommand(
    int IdHorario,
    string NombreCliente,
    string? EmailCliente,
    decimal Total,
    string Estado = "confirmada") : ICommand;
