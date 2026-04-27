using LiteBus.Commands.Abstractions;

namespace Tickets.Application.Commands.DeleteTicket;

public record DeleteTicketCommand(int Id) : ICommand;
