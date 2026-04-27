using LiteBus.Commands.Abstractions;

namespace Reservas.Application.Commands.DeleteReserva;

public record DeleteReservaCommand(int Id) : ICommand;
