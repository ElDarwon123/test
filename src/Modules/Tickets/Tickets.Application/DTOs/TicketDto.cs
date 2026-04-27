namespace Tickets.Application.DTOs;

public record TicketDto(int IdTicket, int IdReserva, int IdAsiento, string CodigoTicket, decimal Precio, DateTime FechaEmision, string Estado, bool Active);
