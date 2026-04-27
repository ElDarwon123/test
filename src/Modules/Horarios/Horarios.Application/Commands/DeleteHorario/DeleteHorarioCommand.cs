using LiteBus.Commands.Abstractions;

namespace Horarios.Application.Commands.DeleteHorario;

public record DeleteHorarioCommand(int Id) : ICommand;
