namespace Tickets.Application.Commands.CreateTicket;

public record CreateTicketCommand(
    int IdReserva,
    int IdAsiento,
    string CodigoTicket,
    decimal Precio,
    string Estado = "activo") : ICommand;
