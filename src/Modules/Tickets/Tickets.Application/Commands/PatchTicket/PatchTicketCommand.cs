using LiteBus.Commands.Abstractions;

namespace Tickets.Application.Commands.PatchTicket;

public record PatchTicketCommand(int IdTicket, int? IdReserva, int? IdAsiento, string? CodigoTicket, decimal? Precio, DateTime? FechaEmision, string? Estado) : ICommand;
