using LiteBus.Commands.Abstractions;

namespace Salas.Application.Commands.DeleteSala;

public record DeleteSalaCommand(int Id) : ICommand;
