using LiteBus.Commands.Abstractions;

namespace Salas.Application.Commands.PatchSala;

public record PatchSalaCommand(int IdSala, string? Nombre, int? Capacidad, string? TipoSala, string? Ubicacion, string? Estado) : ICommand;
