namespace Reservas.Application.DTOs;

public record ReservaDto(int IdReserva, int IdHorario, string NombreCliente, string? EmailCliente, DateTime FechaReserva, decimal Total, string Estado, bool Active);
