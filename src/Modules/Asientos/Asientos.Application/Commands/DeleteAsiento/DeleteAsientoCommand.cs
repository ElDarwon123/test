using LiteBus.Commands.Abstractions;

namespace Asientos.Application.Commands.DeleteAsiento;

public record DeleteAsientoCommand(int Id) : ICommand;
