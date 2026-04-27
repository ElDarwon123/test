using LiteBus.Commands.Abstractions;

namespace Asientos.Application.Commands.PatchAsiento;

public record PatchAsientoCommand(int IdAsiento, int? IdSala, string? Fila, int? Numero, string? TipoAsiento, string? Estado) : ICommand;
