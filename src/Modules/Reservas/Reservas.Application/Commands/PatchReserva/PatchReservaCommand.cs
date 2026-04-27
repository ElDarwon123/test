using LiteBus.Commands.Abstractions;

namespace Reservas.Application.Commands.PatchReserva;

public record PatchReservaCommand(int IdReserva, int? IdHorario, string? NombreCliente, string? EmailCliente, DateTime? FechaReserva, decimal? Total, string? Estado) : ICommand;
